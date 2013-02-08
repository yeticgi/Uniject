dir = File.expand_path(File.dirname(__FILE__))

PackageProject.new "Uniject", dir: dir do
end

PackageProject.new "Uniject.Unity", dir: dir, solution_name: "Uniject" do
  dependencies << Project["Uniject"]
end
