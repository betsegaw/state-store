using System.Collections.Generic;

public class StateStoreConfiguration
{
    public string Name { get; set; }
    public string Token { get; set; }
    public List<ConditionConfigurations> ConditionConfigurations { get; set; }
}

public class Condition
{
    public string Name { get; set; }
    public bool Value { get; set; }
    public string ActionURL { get; set; }
}

public class ConditionConfigurations
{
    public string Name { get; set; }
    public string URL { get; set; }
    public string ConditionSourceURL { get; set; }
    public Condition ConditionTrueValue { get; set; }
    public Condition ConditionFalseValue { get; set; }
}