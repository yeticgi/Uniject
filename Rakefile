require "rexml/document"

MDTOOL = "/Applications/MonoDevelop.app/Contents/MacOS/mdtool"
SOLUTION = "Uniject.sln"
PROJECTS = ["Uniject", "Uniject.Unity"]
PROJECT_VERSION = "1.0.0"
CONFIGURATIONS = ["Debug", "Release"]
NUPKG_CONFIGURATION = "Release"
SOLUTION_PACKAGES = "packages"

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
      mdtool project: project, configuration: configuration
    end
  end

  file nupkg(project) => [dll(project, NUPKG_CONFIGURATION), nuspec(project)] do
    sh "mono --runtime=v4.0 ~/NuGet.exe pack -NoPackageAnalysis #{nuspec project}"
  end
end

desc "remove packages and built assemblies"
task :clean do
  PROJECTS.each { |p| mdtool target: "Clean", project: p }
  rm_rf SOLUTION_PACKAGES
  rm PROJECTS.map { |p| nupkg p }
end

task :default => PROJECTS.map { |p| nupkg p }

