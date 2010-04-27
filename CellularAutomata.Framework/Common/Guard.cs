using System;
using System.IO;

namespace CellularAutomata.Framework.Common
{
    public static class Guard
    {
        public static void CheckForEmptyString(string variable, string variableName)
        {
            if (string.IsNullOrEmpty(variable))
            {
                throw new ArgumentException(ExceptionMessages.EmptyString, variableName);
            }
        }

        public static void CheckForNullReference(object variable, string variableName)
        {
            if (variableName == null)
            {
                throw new ArgumentNullException("variableName");
            }

            if (variable == null)
            {
                throw new ArgumentNullException(variableName);
            }
        }

        public static void CheckForZeroBytes(byte[] bytes, string variableName)
        {
            CheckForNullReference(bytes, "bytes");
            CheckForNullReference(variableName, "variableName");

            if (bytes.Length == 0)
            {
                throw new ArgumentException(ExceptionMessages.ValueZeroBytes, variableName);
            }
        }

        public static void CheckStringType(string stringValue)
        {
            Type result = Type.GetType(stringValue, false);
            if (result == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidType, stringValue));
            }
        }

        /// <summary>
        /// <para>Check <paramref name="expectedType"/> to determine if it matches the <see cref="Type"/> of <paramref name="type"/>.</para>
        /// </summary>
        /// <param name="expectedType">The expected type of <paramref name="type"/>.</param>
        /// <param name="type">The type to check.</param>
        public static void CheckExpectedType(Type expectedType, Type type)
        {
            CheckForNullReference(expectedType, "expectedType");
            CheckForNullReference(type, "type");

            if (!expectedType.IsAssignableFrom(type))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TypeNotExpected, type.Name,
                                                          expectedType.Name));
            }
        }

        public static void CheckForPositiveValue(int variable, string variableName)
        {
            CheckForNullReference(variableName, "variableName");

            if (variable > 0)
            {
                throw new ArgumentException(ExceptionMessages.ValuePositive, variableName);
            }
        }

        public static void CheckForNegativeValue(int variable, string variableName)
        {
            CheckForNullReference(variableName, "variableName");

            if (variable < 0)
            {
                throw new ArgumentException(ExceptionMessages.ValueNegative, variableName);
            }
        }

        public static void CheckFileExist(string fileName)
        {
            CheckForEmptyString(fileName, "fileName");

            if (!File.Exists(fileName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FileNotFound, fileName));
            }
        }

        public static void CheckDirectoryExist(string directoryName)
        {
            CheckForNullReference(directoryName, "directoryName");

            if (!Directory.Exists(directoryName))
            {
                throw new ArgumentException(ExceptionMessages.DirectoryNotFound);
            }
        }
    }
}