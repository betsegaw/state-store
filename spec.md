# Introduction

IFTTT is a powerful service that lets you connect diffrent services together. 

The one short-coming is that while you can make simple connetions using "If ___ then ___", IFTTT does not have a feature to store state. So you can't create statments like "If I **am not** home and you see movement on my nest, call me".

State-store is a docker based image that acts as the `and` operator and enabled you to create more complex automations.

# Getting Started

At the core of state-store is a configuration file that you can use to create and update different automations.

## Example

You want to create an automation that every time you have a missed call or you get a text message, a new task is added to your favorite task manager. However, and here is the key point, you want to **not** add tasks if you already have a task for following up with that person.

Here is a basic configuration file that can use to set this up.

```
Name: Text And Call Bookmarker
Token: MY_UNIQUE_TOKEN
Conditions:
    - Name: User Called
      URL: usercalled
      ConditionSourceURL: https://some/api/call
      ConditionTrueValue:
        Name: Value
        Value: True
        ActionURL: https://some/api/to/call/if/true
      ConditionFalseValue:
        Name: Value
        Value: False
        ActionURL: https://some/api/to/call/if/false
    - Name: User Texted
      URL: usertexted
      ConditionSourceURL: https://some/other/api/call
      ConditionTrueValue:
        Name: Value
        Value: True
        ActionURL: https://some/other/api/to/call/if/true
      ConditionFalseValue:
        Name: Value
        Value: False 
        ActionURL: https://some/other/api/to/call/if/false
```

The above basic YAML config file enables you to create a simple setup where depending on which URL you are calling, you will get different results.