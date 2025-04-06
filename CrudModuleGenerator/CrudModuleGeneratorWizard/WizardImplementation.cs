using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrudModuleGeneratorWizard
{
    public class WizardImplementation : IWizard
    {
        private string entityName = "";
        private string projectName = "";
        private string solutionDirectory = "";
        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
            string currentFilePath = projectItem.FileNames[1];

            var folderMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { $"{entityName}Controller.cs", $@"{projectName}.Api\\Controllers" },
                { $"{entityName}AppService.cs", $@"{projectName}.Application\\Services" },
                { $"I{entityName}AppService.cs", $@"{projectName}.Application\\Interfaces" },
                { $"{entityName}DomainService.cs", $@"{projectName}.Domain\\Services" },
                { $"I{entityName}DomainService.cs", $@"{projectName}.Domain\\Interfaces\\Services" },
                { $"{entityName}Repository.cs", $@"{projectName}.Infrastructure\\Repositories" },
                { $"I{entityName}Repository.cs", $@"{projectName}.Domain\\Interfaces\\Repositories" },
                { $"Add{entityName}ViewModel.cs", $@"{projectName}.Application\\ViewModels\\{entityName}" },
                { $"Update{entityName}ViewModel.cs", $@"{projectName}.Application\\ViewModels\\{entityName}" },
                { $"{entityName}ViewModel.cs", $@"{projectName}.Application\\ViewModels\\{entityName}" },

            };
            var projectsDir = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(currentFilePath), @".."));

            string itemName = projectItem.Name;

            var customPath = folderMap.FirstOrDefault(x => x.Key == itemName);

            string destinationPath = Path.Combine(projectsDir, customPath.Value, customPath.Key).Replace("\\\\", "\\");
            string targetDirectory = Path.GetDirectoryName(destinationPath);

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            File.Move(currentFilePath, destinationPath);
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            solutionDirectory = replacementsDictionary["$solutiondirectory$"];

            var splitedSolutionDirectory = solutionDirectory.Split('\\');
            projectName = splitedSolutionDirectory[splitedSolutionDirectory.Length - 2];

            replacementsDictionary["$solutiondirectory$"] = solutionDirectory.Replace(projectName, "");

            string safeItemName = replacementsDictionary["$safeitemname$"].ToLower();

            entityName = char.ToUpper(safeItemName[0]) + safeItemName.Substring(1);

            string lowerCaseEntityName = safeItemName;

            replacementsDictionary.Add("$EntityName$", entityName);
            replacementsDictionary.Add("$LowerCaseEntityName$", lowerCaseEntityName);
            replacementsDictionary.Add("$ProjectName$", projectName);

            //var aa = File.ReadAllText(@"C:\Users\vitor\AppData\Local\Microsoft\VisualStudio\17.0_b4b20eaeExp\Extensions\Valcir Pfiffer\CrudModuleGeneratorWizard\1.0\ItemTemplates\CSharp\1033\CrudModuleGenerator\Api\Controller.cs");
            //aa.Replace("$EntityName$", entityName);
            //aa.Replace("$LowerCaseEntityName$", lowerCaseEntityName);
            //File.WriteAllText($@"{solutionDirectory}\\{projectName}\\{projectName}.Api\\Controllers\\{entityName}Controller.cs", aa);
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}

