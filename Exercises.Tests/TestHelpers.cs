using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentAssertions.Execution;

namespace Exercises
{
    public static class TestHelpers
    {
        private static readonly Assembly ExercisesAssembly = typeof(Exercises.AssemblyInfo).Assembly;

        public static Type GetType(string name)
        {
            var type = ExercisesAssembly
                .GetTypes()
                .SingleOrDefault(t => t.Name.StartsWith(name));
            if (type is null)
                throw new AssertionFailedException($"Missing type: {name}");
            return type;
        }

        public static MethodInfo GetExtensionMethod(Type extendedType, string name)
        {
            var methodInfo = GetExtensionMethods(extendedType).SingleOrDefault(m => m.Name == name);
            if (methodInfo is null)
                throw new AssertionFailedException($"Missing extension method: {name} for type {extendedType.Name}");
            return methodInfo;
        }

        public static IEnumerable<MethodInfo> GetExtensionMethods(Type extendedType) => ExercisesAssembly
            .GetTypes()
            .Where(t => t.IsSealed && !t.IsGenericType && !t.IsNested)
            .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false))
                .Where(m => m.GetParameters()[0].ParameterType == extendedType));
    }
}