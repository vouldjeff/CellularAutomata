using System;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Static class, which creates <see cref="IRule"/> objects.
    /// </summary>
    public static class RuleFactory
    {
        /// <summary>
        /// Creates a new <see cref="IRule"/> instance using the rule name array of <see cref="object"/> to be applied.
        /// </summary>
        /// <param name="name">The name of the rule to be created.</param>
        /// <param name="args">Orderd arguments needed for creating a particular rule (can be <see cref="Nullable"/>).</param>
        /// <returns>The initialized <see cref="IRule"/> object.</returns>
        public static IRule Create(string name, object[] args)
        {
            return Create(Utilities.GetRuleType(name), args);
        }

        /// <summary>
        /// Creates a new <see cref="IRule"/> instance using the rule <see cref="Type"/> array of <see cref="object"/> to be applied.
        /// </summary>
        /// <param name="ruleType">The <see cref="Type"/> of the rule to be created.</param>
        /// <param name="args">Orderd arguments needed for creating a particular rule (can be <see cref="Nullable"/>).</param>
        /// <returns>The initialized <see cref="IRule"/> object.</returns>
        public static IRule Create(Type ruleType, object[] args)
        {
            return (IRule) Activator.CreateInstance(ruleType, args);
        }
    }
}