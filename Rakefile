require "rexml/document"

SOLUTION = "Uniject.sln"
PROJECTS = ["Uniject", "Uniject.Unity"]
PROJECT_VERSION = "1.0.0"
CONFIGURATIONS = ["Debug", "Release"]
NUPKG_CONFIGURATION = "Release"
SOLUTION_PACKAGES = "packages"

def windows?
  true
end

def cygpath(win_path)
  `cygpath -u "#{win_path}"`.chomp
end

def _system(*args)
  puts *args
  system *args
end

if windows?
  ENV.each do |env, value|
    upper_env = env.upcase
    if env != upper_env && ENV[upper_env]
      ENV[upper_env] = nil
    end
  end
end

module Mono
  class << self
    Location = if windows?
                 "C:\\Program Files (x86)\\Mono-2.10.9\\bin\\mono.exe"
               else
                 "mono"
               end
    
    def run(command, opts = {})
      if windows?
        _system "'#{cygpath Location}' --runtime=v4.0 #{command}"
      else
        system "#{Location} --runtime=v4.0 #{command}"
      end
    end
  end
end

module NuGet
  class << self
	  Location = '"C:\\Users\\pelarro\\bin\\NuGet.exe"'

	  def pack(nuspec, opts = {})
      if windows?
        nuspec = generate_windows_nuspec nuspec
      end
      Mono.run "#{Location} pack #{'-NoPackageAnalysis' if opts[:package_analysis] == false} #{nuspec}"
	  end
    
    def generate_windows_nuspec(nuspec)
      xml = REXML::Document.new File.new(nuspec)
      xml.elements.each "package/files/file" do |file|
        ["src", "target"].each do |attr|
          file.attributes[attr].gsub! "/", "\\"
        end
      end
      windows_nuspec = nuspec.gsub ".nuspec", "-windows.nuspec"
      File.open windows_nuspec, "w" do |file|
        xml.write file
      end
      windows_nuspec
    end
  end
end

module MDTool
  class << self
    Location = if windows?
                 '"C:\\Program Files (x86)\\MonoDevelop\\bin\\mdtool.exe"'
               else
                 "/Applications/MonoDevelop.app/Contents/MacOS/mdtool"
               end

    def build(solution_file, opts = {})
      run_target solution_file, "Build", opts
    end

    def clean(solution_file, opts = {})
      run_target solution_file, "Clean", opts
    end
      
    def run_target(solution_file, target = "Build", opts = {})
      raise "no configuration specified" unless opts[:configuration]
      raise "no project specified" unless opts[:project]
      Mono.run "#{Location} build -t:#{target} -c:#{opts[:configuration]} -p:#{opts[:project]} #{solution_file}"
    end
  end
end

def dll(project, configuration)
  "bin/#{configuration}/#{project}.dll"
end

def nupkg(project)
  "#{project}.#{PROJECT_VERSION}.nupkg"
end

def source(project)
  Dir.glob "#{project}/*.cs"
end

def nuspec(project)
  "#{project}/#{project}.nuspec"
end

def packages(project)
  REXML::Document.new(File.new(package_config(project))).elements.enum_for(:each, "packages/package").map do |package|
    {
      :id => package.attributes["id"],
      :version => package.attributes["version"]
    }
  end
end

def package_dir(package)
  "#{SOLUTION_PACKAGES}/#{package[:id]}.#{package[:version]}"
end

def installed_packages(project)
  packages(project).map do |package|
    package_dir package
  end
end

def package_config(project)
  "#{project}/packages.config"
end

def package_sources
  REXML::Document.new(File.new("#{Dir.home}/.config/NuGet/NuGet.config")).elements.enum_for(:each, "configuration/packageSources/add").map do |source|
    source.attributes["value"]
  end
end

def mdtool(opts)
  puts "#{MDTOOL} build -t:#{opts[:target] || "Build"} -c:#{opts[:configuration] || NUPKG_CONFIGURATION} -p:#{opts[:project]} #{SOLUTION}"
  system "#{MDTOOL} build -t:#{opts[:target] || "Build"} -c:#{opts[:configuration] || NUPKG_CONFIGURATION} -p:#{opts[:project]} #{SOLUTION}"
end

PROJECTS.each do |project|
  packages(project).each do |dependency|
    file package_dir(dependency) => package_config(project) do
      install_packages = packages(project).map do |package|
        %|manager.InstallPackage("#{package[:id]}", SemanticVersion.Parse("#{package[:version]}"));|
      end

      package_repositories = package_sources.map do |source|
        %|PackageRepositoryFactory.Default.CreateRepository("#{source}")|
      end

      csharp = <<END
using NuGet;

var repo = new AggregateRepository(new [] { #{package_repositories.join ", "} });
var manager = new PackageManager(repo, "#{SOLUTION_PACKAGES}");
#{install_packages.join "\n"}
END

      system %[echo '#{csharp}' | csharp "-lib:#{Dir.home}/Library/Application Support/MonoDevelop-3.0/LocalInstall/Addins/MonoDevelop.PackageManagement.0.3" -reference:NuGet.Core.dll]
    end
  end

  CONFIGURATIONS.each do |configuration|
    file dll(project, configuration) => installed_packages(project) + source(project) do
      MDTool.build SOLUTION, project: project, configuration: configuration
    end
  end

  file nupkg(project) => [dll(project, NUPKG_CONFIGURATION), nuspec(project)] do
    NuGet.pack nuspec(project), package_analysis: false
  end
end

desc "remove packages and built assemblies"
task :clean do
  PROJECTS.each { |p| mdtool target: "Clean", project: p }
  rm_rf SOLUTION_PACKAGES
  rm PROJECTS.map { |p| nupkg p }
end

task :default => PROJECTS.map { |p| nupkg p }

