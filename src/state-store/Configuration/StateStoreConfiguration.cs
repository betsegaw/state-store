using System.Collections.Generic;
using System.IO;

public class StateStoreConfiguration
{
    private static StateStoreConfiguration stateStoreConfigurationInstance;

    public static StateStoreConfiguration StateStoreConfigurationInstance {
        get {
            if (stateStoreConfigurationInstance == null) {
                YamlDotNet.Serialization.Deserializer x = new YamlDotNet.Serialization.Deserializer();
                stateStoreConfigurationInstance = x.Deserialize<StateStoreConfiguration>(File.ReadAllText(@"C:\Users\betse\Source\Repos\state-store\src\state-store\SampleConfigurations\SampleConfiguration.yaml"));
            }

            return stateStoreConfigurationInstance;
        }
    }
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