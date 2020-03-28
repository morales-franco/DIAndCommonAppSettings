# Dependency Injection & Common App Settings

Thre ways to save & retrieve common app settings in net core applications.

### Immutable Common App Settings
1. Use appSettings + IConfiguration<> & Dependency Injection
2. Use appSettings + Singleton 

### Mutable Common App Settings
1. Use Singleton Service + IServiceScopeFactory to inject a scope repository in a singleton service
