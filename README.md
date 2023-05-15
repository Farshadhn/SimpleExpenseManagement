[![Farshad](https://farshadhn.ir/images/Farshad_small.png)](https://farshadhn.ir) 
# Lookif framework
# Develop a Dashboard in ✨ 5 minutes ✨
 Lookif framework is a lightweight multi-layered framework that enables you to create a dashboard in less than 5 minutes. 
 This repo is just a  sample about how to use these libraries. It is not focesd on UI Design or how to develop a greate automated dashboard.
 Although, Right now it is in Persian, I'll inject other languages.
 
 
 
### Lookif framework is :
 - A framework that helps you to create a handy prototype in no time!

### Lookif framework is not:
 - A full framework that you can relay on. It can help you to get rid of common operations. For more complex solutions you need to override some functions.

 
## Features
- Using internal Automapper help you to map your models without defining any profilers. You can also create special profiler where ever you want
- It supports Auto Database Migration. You do not need to define Dbsets or any thing retlated to it.
- Generic CRUD is supported in service and controll level.
- By using Blazor and .Net, we can share our data models throughout your API and UI and even mobile phone.
- Identity is supported for authorization and authentication.
- In blazor, By using reflection, any models can be translated to a simple form to insert new data. You can even Set its label or input size.
- In blazor, By using reflection, any models can be translated to a simple grid to show inserted data. You can set column's size.
- JTW Token is supported.

 


## Remember 
> This multi-layered framework helps you 
> to create your prototype fast. you need to expand it 
>and override few main funtions, if you need it to fit into your special needs.

 

## Tech

Dillinger uses a number of open source projects to work properly:

- [Blazor] - Front-side!
- [.Net 6 API] - Back-End side

 

## Installation
 

For each layer you need to install corresponding library.

```sh
dotnet add package Lookif.Library.Common --version 2.2.0
dotnet add package Lookif.Layers.Core --version 2.0.3.5
dotnet add package Lookif.Layers.Data --version 2.0.2
dotnet add package Lookif.Layers.Service --version 2.0.1
dotnet add package Lookif.Layers.WebFramework --version 2.2.0
dotnet add package Lookif.UI.Component --version 3.2.0
```

 

## Libraries

These are third party libraries we use.

| name | fullname |
| ------ | ------ |
| Blazored | Blazored.LocalStorage |
| Blazorise | Blazorise.Bootstrap | 

# Development
 

#### API

#### 1.Create your Entity model ( If you want to use Temporal or history tables you just need to add derived from Itemporal interface)
```
public class Tag : BaseEntity<Guid>, IActive
{
    public string Title { get; set; }
    public string Color { get; set; }
    public bool IsActive { get ; set ; }
}
```
#### 2.Create Empty IService ( By using IScopedDependency,ITransientDependency,ISingletonDependency, you define its DependencyInjection. you do not need to add .AddScope() anywhere)
```
public interface ITagService : IBaseService<Tag, Guid>, IScopedDependency
{
    
}
```

#### 3.Create Empty Service - Crud operations are implemented in BaseService
```
public class TagService : BaseService<Tag, Guid>, ITagService, IScopedDependency
{
    private readonly IRepository<Tag> _repository; 
    public TagService(IRepository<Tag> repository ) : base(repository)
    {
        _repository = repository; 
    }
}
```
#### 4.Create Empty Controller - Crud operations are implemented in CrudController

```
[ApiVersion("1")]
public class TagController : CrudController<TagDto, TagSelectDto, Tag, ITagService>
{
    private readonly IMapper _mapper;
    public TagController(IMapper mapper) : base(mapper)
    {
        _mapper = mapper;
    }

}
```
#### 5.Define TagDto,TagSelectDto.
TagDto is a DTO related to Post a new Tag.
TagSelectDto is a DTO related to Get Tags.
```
public class TagDto : BaseDto<TagDto, Tag, Guid>, ITagDto
{
    public string Title { get; set; }
    public bool IsActive { get; set; }
}

public class TagSelectDto : BaseDto<TagSelectDto, Tag, Guid>, ITagSelectDto
{
    public string Title { get; set; }
    public bool IsActive { get; set; }
}
```
#### 6.There is no other steps in API.
 
 
 
 
 # UI

#### 1.Create your Model in shared layer
```
public interface ITagDto : IEntity, IActive
{
    public string Title { get; set; }
    public string Color { get; set; } 
}

public interface ITagSelectDto : IEntity , ITagDto
{
}

```
#### 2.Create Dto in UI 
```
public class TagDto : BaseDto, ITagDto
{
    public string Title { get; set; }
    public string Color { get; set; }
 
    [Hidden]
    [HiddenDto(HiddenStatus.Create)]
    public bool IsActive { get; set; }

}

public class TagSelectDto :  TagDto , ITagSelectDto
{
}
```

#### 3.Create your page using One line
```
<CrudComponent  TItem="TagDto" TSelectItem="TagSelectDto"  Resource="Localizer" FormName="Tag" ></CrudComponent>

```
# Done!!
 
 
 
 
 
## License

MIT

**Free Software, Hell Yeah!**
   
