# ActiveDirectory B2C - Avalonia Sample
 A small sample that demonstrates how to authenticate with [Active Directory B2C](https://docs.microsoft.com/azure/active-directory-b2c/overview?WT.mc_id=dotnet-Avalonia-mijam) using [Avalonia](https://avaloniaui.net).

![screenshot](/assets/screenshot.png)

# Getting Started 

## Prerequisite
If you don't have an [Azure subscription](https://docs.microsoft.com/azure/guides/developer/azure-developer-guide?WT.mc_id=dotnet-Avalonia-mijam#understanding-accounts-subscriptions-and-billing), create a [free account](https://azure.microsoft.com/free/?ref=microsoft.com&utm_source=microsoft.com&utm_medium=docs&utm_campaign=visualstudio&WT.mc_id=dotnet-Avalonia-mijam) before you begin.

---

## Step 1: [Create an Active Directory B2C Tenant](https://docs.microsoft.com/azure/active-directory-b2c/tutorial-create-tenant?WT.mc_id=dotnet-Avalonia-mijam)

---
## Step 2: [Register the application](https://docs.microsoft.com/azure/active-directory-b2c/tutorial-register-applications?tabs=app-reg-ga&WT.mc_id=dotnet-Avalonia-mijam)
---
## Step 3: [Create the user flows](https://docs.microsoft.com/azure/active-directory-b2c/tutorial-create-user-flows?WT.mc_id=dotnet-Avalonia-mijam)
---
## Step 4: Modify the project Configuration.cs 

```csharp
internal static class Configuration
{
    internal static readonly string TenantName = "Update_This_Value";
    internal static readonly string ClientId = "Update_This_Value";

    ...
}
```
---
## Step 5: Bask in the glory of your success!
otherwise open an issue and I'll try and help.  

---


# Learn more about [Avalonia](https://avaloniaui.net/)

* [Docs](https://avaloniaui.net/docs)
* [Source Code](https://github.com/AvaloniaUI/Avalonia)
* [Awesome Avalonia](https://github.com/AvaloniaCommunity/awesome-avalonia)
* [Open Collective](https://opencollective.com/Avalonia)