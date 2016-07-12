﻿using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ApiVersioningModule.Swagger
{
    public class SwaggerUrlVersionDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            if(swaggerDoc.paths.Any(x => x.Key.Contains("{version}") || x.Key.ToLower()
                                                                         .Contains(".")))
            {
                var newPaths = new Dictionary<string, PathItem>();

                foreach(var path in swaggerDoc.paths)
                {
                    var newPathKey = path.Key.ToLower();

                    if(newPathKey.Contains("{version}"))
                    {
                        newPathKey = newPathKey.Replace("{version}", swaggerDoc.info.version);
                    }

                    if(newPathKey.Contains("."))
                    {
                        newPathKey = Regex.Replace(newPathKey, @"(/[a-z0-9\.]+\.)([a-z0-9]+)/", x => "/" + x.Groups[2].Value + "/");
                    }

                    newPaths.Add(newPathKey, path.Value);
                }

                swaggerDoc.paths = newPaths;
            }

            foreach(var pathItem in swaggerDoc.paths.Where(x => IsPathItemContainsPathsWithParameter(x.Value, "version"))
                                              .Select(x => x.Value))
            {
                RemoveParameterFromPathItem(pathItem, "version");
            }
        }

        private bool IsOperationContainsParameter(Operation operation, string name)
        {
            return operation != null && operation.parameters != null && operation.parameters.Any(x => x.name == name);
        }

        private void RemoveParameterByName(Operation operation, string name)
        {
            if(operation != null)
            {
                var parameter = operation.parameters.FirstOrDefault(x => x.name == name);
                operation.parameters.Remove(parameter);
            }
        }

        private bool IsPathItemContainsPathsWithParameter(PathItem pathItem, string name)
        {
            return IsOperationContainsParameter(pathItem.get, name)
                   || IsOperationContainsParameter(pathItem.delete, name)
                   || IsOperationContainsParameter(pathItem.head, name)
                   || IsOperationContainsParameter(pathItem.patch, name)
                   || IsOperationContainsParameter(pathItem.post, name)
                   || IsOperationContainsParameter(pathItem.put, name)
                   || IsOperationContainsParameter(pathItem.options, name);
        }

        private void RemoveParameterFromPathItem(PathItem pathItem, string name)
        {
            RemoveParameterByName(pathItem.get, name);
            RemoveParameterByName(pathItem.delete, name);
            RemoveParameterByName(pathItem.head, name);
            RemoveParameterByName(pathItem.patch, name);
            RemoveParameterByName(pathItem.post, name);
            RemoveParameterByName(pathItem.put, name);
            RemoveParameterByName(pathItem.options, name);
        }
    }
}