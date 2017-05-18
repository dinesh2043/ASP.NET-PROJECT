# ASP.NET-Web-application
## Back end developed with generic repository, SQL server and Entity framework using Layered artitecture

### Only Server side back end implementation is my work. The general overview of the application can be seen from the following video link 

[For Application Overview video click here !!](https://www.youtube.com/watch?v=GuURyUUBgrw&feature=youtu.be)

### Application Development Process

Our project requirement was to provide the services to buy and sell skills by donating certain percentage of the money to the social service organization. To make these ser-vices reliable and secure needed a lot of discussion. After discussion we decided to track the complete process of buying, selling and donation. Our project requirement was also to provide the feedback services from users and social service organization which will help the users to select an honest buyer and seller of skill and social service organization. 

Since this is a charity based application with financial transactions it forced us to think about security and transparency of the application. For transparency of the application we decided to make the whole process of transaction track able by the user who is di-rectly involved in the process. We decided to give honors to the users according to the positive feedback received and amount of donation provided to the social service or-ganization. 

The project requirement was to achieve this entire requirement, dynamically through the web service. This is the process I followed to create the software architecture for the web application. First of all I decided to follow the layered software architecture devel-opment process to achieve my goal. In layered software application development pro-cess we can divide the whole application into different layers according to the distinct task they are performing. 
   
To achieve the project requirement I decided to divide my web application into data source, services, data access layer, business layer, presentation layer, users and exter-nal system. Since this application was supposed to provide services to the mobile client, we can consider it as an external system.


### Data Source Development Process

My task was to create the server side back end for the application. According to the application requirement I should be able to store large amount of information in the or-ganized collection. All the process of saving, updating, fetching and deleting of data in an organized collection should be done by the application. 

##### Database

The organized collection of data being stored in logically divided tables, according to the relationship among them, is called database. Database table is a set of data values which is organized using a model of vertical columns and horizontal rows. The point of intersection between the rows and column is called cell. A table has specified numbers of columns but it can have any number of rows. Each row is identified by the unique key index called ROWID. ROWID is an address of row which is always unique and set as primary key.    

##### Database Management System

The system designed to save, update, fetch and delete data in database table according to its relation is called database management system. In our application development process we designed our database management system discussing with all the team members in a meeting. It is always good to design the database system after the group discussion because it makes our view broader which helps to analyze data in a broader prospective. 

In our database design we divided the tables according to the distinct nature of data and its relationship with the data stored in another table. We decided data types to be used for storing data according to nature of data stored in the column. Primary key is a unique identifier called ROWID, which is used to identify the set of data stored in a row. Primary key column is used to identify each set of data stored in database table. For-eign key column in a table stores primary key value of the other table according to its relationship with that table. We decided to use Globally Unique Identifier (GUID) data types for primary and foreign key for the security of data in the database table. This helps us to make our database safe from information disclosure attack.

When the database design was ready I got a task to implement that design in SQL Server 2012. For that purpose I used an IDE called SQL Server Management Studio 2012 because it supports all the functionality of SQL Server and it was fully compatible with Visual Studio 2012. It provides large variety of tools to design database. Using this IDE we can easily create database and its tables with relationships by using both graph-ical user interface and using SQL query language. Using graphical user interface we can define the connection strategies, I have used windows authentication strategy for connecting to my database. Security, user role, server logs and triggers can be en-forced for database by using graphical tools while creating the database. Management studio helps us to deploy our database in the cloud services. Database in the manage-ment studio also can be used locally by connecting to the visual studio. Database can be created by executing SQL query in management studio. 

After that I grouped all the data which were supposed to be stored in the database ac-cording to their category in separate tables. All the tables were connected with each other according to their relationships by the help of primary and foreign key in the ta-bles. We can create tables in the database by executing the SQL query shown in the following lines.

```
CREATE TABLE [dbo].[Task] (
    [taskId]      UNIQUEIDENTIFIER CONSTRAINT [DF_Task_taskId] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [owner]       NVARCHAR (50)    NULL,
    [doer]        NVARCHAR (50)    NULL,
    [startedOn]   DATETIME         NULL,
    [endline]     NVARCHAR (MAX)   NULL,
    [deadline]    DATETIME         NULL,
    [description] NVARCHAR (MAX)   NULL,
    [categoryId]  UNIQUEIDENTIFIER NULL,
    [status]      NVARCHAR (MAX)   NULL,
    [skillId]     UNIQUEIDENTIFIER NULL,
    [updateDate]  DATETIME         DEFAULT (getdate()) NULL,
    [money]       VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([taskId] ASC),
    CONSTRAINT [FK_Task_Category] FOREIGN KEY ([categoryId]) REFERENCES [dbo].[Category] ([categoryId]),
    CONSTRAINT [FK_Task_Skill] FOREIGN KEY ([skillId]) REFERENCES [dbo].[Skill] ([skillId])
);

```
Figure 7 Task Table create statement

This code is used to create Task table which has a relationship with the category and skill tables. This table contains 12 columns with different data types according to the data to be stored in this table. This process was repeated to create all the required ta-bles. After implementing all the tables and relationships, required database structure was achieved. It is shown in the following figure.
![img](https://github.com/dinesh2043/ASP.NET-Web-application/blob/master/img1.jpg)   

Figure 6 Database structure of Ubuoy Application

According to our project requirement this was the initial database structure I designed. 

After implementing database, the next step is to connect that database from a server to use it. For that purpose I used ADO.NET Entity Framework because it helps us to sepa-rate our application from the relational or logical model by providing a layer of abstrac-tion on top of relational model. When the database was ready, I created the EDM from the existing Ubuoy database by using Entity Framework. This model is automatically created by the framework which can be edited and updated using designer. This EDM consists of a collection of entities, entity types, entity sets and their relationship. EDM is used as a data source for this application. During this process a connection string is created by the framework and it is stored in the web.config file. This connection string is used by the application for performing CRUD operation to the database. The following piece of code is a connection string generated by the framework;

```
connection-String="metadata=res://*/Model.UbuoyDbModel.csdl|res://*/Model.UbuoyDbModel.ssdl|res://*/Model.UbuoyDbModel.msl;provider=System.Data.SqlClient;providerconnection-string=&quot;datasource=(LocalDB)\v11.0;attachdbfilename=|DataDirectory|\Ubuoy
```

Figure 7 Connection String generated by entity framework

This connection string is used by the application to connect to the database and to inter-act to the database table. 

### Data Access Layer Development Process

When the data source of Ubuoy application was ready I designed a data access layer for my application. This layer is used to access the data stored in the database. In appli-cation development process we use repository classes to achieve this goal. It is the best practice to create an interface repository class which contains method signature and constant declarations. That interface is implemented in all the repository classes. In normal application development process we create separate repository class for each database table. When developing an application with large numbers of tables, pro-grammers end up writing large amount of similar code which decreases the productivity of the development team.

There is a new concept of creating a generic repository class which can be used as a specific repository class by passing the entity name to this class at run time. To imple-ment generic repository class first I created an interface for that class. In the following lines there is a code for creating interface class;
```
   public interface IRepository<T>: IDisposable where T : class
    {
        IQueryable<T> Fetch();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T Single(Func<T, bool> predicate);
        T First(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
    }

```
Figure 8 Code used to create interface of generic repository class

In the above code interface class uses generic variable T which can be any entity and it is defined as IDisposable to release the allocated resources. All the required method signatures and constants are declared in this class.

After that I created a generic repository class to implement this interface. The interface class is implemented as follows;
```
   public class GenericRepository<T> : IRepository<T> where T : class{}
```
Figure 9 Implementation of interface in generic repository class
 
In place of T we pass the entity name while calling the method of generic repository class and during the run time the compiler generates the repository class of that specific entity to get the desired output.

Due to the support of IObjectSet interface and ObjectContext class with generic Cre-ateObjectSet<TEntity>() method in Entity Framework 4.0, it is possible to implement generic repository class. I have implemented all these features of entity framework as follows;

```
      private ObjectContext _context;  
      private IObjectSet<T> _objectSet;

      public GenericRepository(): this(new Model.Ubuoy_DB_ModelEntities()){}

      public GenericRepository(ObjectContext context){ 
      _context = context;
               _objectSet = _context.CreateObjectSet<T>();

```
Figure 10 Implementation of Object Context and Object Set

In the above code first of all I have initialized object context and object set then the enti-ty container name Ubuoy_DB_ModelEntities is used as a datasource for repository classe. Then the objectContext and the objectSet are used to implement generic meth-od CreateObjectSet<T>(). After this it is ready to implement CRUD operations. In CRUD operation I have used exception handling for getting rid of exception in runtime and defend the application DoS attack.

First of all I have implemented Find() method in my generic class which returns a col-lection of data which satisfies the given condition. It is one of the most important meth-ods in the CRUD operation. Following lines of code shows how it was implemented:

```
   public IEnumerable<T> Find(Func<T, bool> predicate){ 
      try{ 
      return _objectSet.Where<T>(predicate); 
      }catch (InvalidOperationException ex)
                  { return null; }
        }


```
Figure 11 Find method implementation in repository

In the above piece of code I have made this method public, which makes this method accessible from business layer class. It returns the collection of data so that I have used IEnumerable<T> which satisfies the given condition. In programming the given condi-tion is called predicate. I have used try catch statement for exception handling which prevent the crash of the application if any exception occurs in the run time returning the null value. It also helps the application from DoS attack.

In Add() method the values of entity is obtained from the business layer and it was pushed into the database table using this method. Following code shows how it is im-plemented:

```
   public void Add(T entity){ 
      if (entity == null){ 
      throw new ArgumentNullException("entity"); 
      }
       _objectSet.AddObject(entity)
      }   
```
Figure 12 Add methods in repository class

This method is used to save entity and we do not need to return any values so that void is used. By using frameworks objectSet, AddObject() method we can save the entity into the database table. For updating the data in the table we can use framework At-tach() method. All the other implementation is similar to Add() method. Delete() method is also similar, the only difference is that one has objectSet, DeleteObject() method. It is used to delete record in the database.

To persist the add, update and delete operations in the database we need to implement and call the SaveChanges() method every time after performing these operations.
An example of save changes is shown in the following code:
```
      public void SaveChanges(){
          _context.SaveChanges(); 
         }
```
Figure 13 SaveChanges method

In the above method objectContext, SaveChanges() method is used to persist the changes in table. This method ensures that the changes have been saved.

When dealing with the database from the server side, it is always important to release resources after the desired operation is achieved because it increases the performance of the application. In the following code it shows how to use Dispose() should be used;

```
   public void Dispose(){
      Dispose(true);
                  GC.SuppressFinalize(this);
              }  
```
Figure 14 Dispose method

When we call this method from the business layer it triggers the private method in the repository class by passing the bool value of the method and it releases the resources.
In the following code the process is shown;

```
   protected virtual void Dispose(bool disposing){ 
      if (disposing){ 
      if (_context != null){ 
      _context.Dispose();
                   _context = null; 
       }
                  }
              }
```
Figure 15 Dispose method implementation

Above code uses the ObjectContext Dispose() method to release resources of the con-text and sets it value to null.

After implementing all of these my data access layer is ready for server to implement CRUD operations. This complete layer is implemented using Entity Framework which has separated my database and data access layer by providing the higher level of ab-straction and speed up whole application process. Due to the implementation of one generic repository class it has reduced large no of code in my application. This helped me to concentrate on the higher layer of the application development. When the data access layer was ready, I started working on the business logic layer.

### Business Logic Layer Development Process

BLL is used to provide methods for the presentation layer to access the data on the da-tabase. This is the most important part of the application development process because in this layer all the business logic of the application is implemented. This layer is used to implement security for the server side of application by authentication of user, validating the user inputs and prevent SQL injection from the client inputs. Security is enforced in this layer to preserve the application from middle man attack because if they bypass the security in the presentation layer, this layer prevents the attack. This layer separates the DAL and presentation layer, which makes the application mentionable and reusable. If our business logic changes, we can make changes in this layer and the other layers remain the same.   

I have created different classes for each entity in the database which helps in separat-ing the business logic to improve the maintainability of the application. BLL is used for processing complex business rules, transforming data and applying policies for valida-tion. After having different classes for each entity it is easier to avoid tight coupling be-tween the layers. BLL classes are created in such a way that they do not have any de-tailed knowledge of the DAL classes. Business layer can just use the methods in the DAL without knowing the entire class and this is the basic principle of application devel-opment in layered architecture.

In this section I am going to discuss how to implement the classes in the business layer. After designing and finalizing the classes to be used, I started implementing BLL to ac-cess data from DAL. First of all I started initializing the generic repository in a business layer by providing the entity value. It enables the generic repository class to act as a repository class of that specific entity. Initialization can be done as follows:
```
      private GenericRepository<Category> categoryRepository; 
```
Figure 16 Initialization of category repository

In the above code we pass entity Category in generic repository class to get category repository class in run time. After this we need to construct a constructor to achieve that functionality. In the code below it shows how to construct the category repository; 
```
      public CategoryBusinessObjects(){ 
         this.categoryRepository = new GenericRepository<Category>(); 
         }
```
Figure 17 Constructor for generic repository

After this constructor has been created we can use it to implement the CRUD operation by using this repository to access the methods in DAL. I am going to discuss how to insert a record in the database table using this class. The following piece of code shows how to implement that:

```
   public bool AddCategory(string name, string description, string image){ 
         categoryRepository.Add(new Model.Category() { Name=name, De-scription=description, image = image });
                     categoryRepository.SaveChanges();
                     return true;
                 }
```
Figure 18 AddCategory method in BLL 

This method is used by the class of presentation layer to pass the values of name, de-scription and image. When this method is called from the presentation layer with all the required parameters it calls the Add() method in the repository class by passing entity category with its values. In repository class this values of the entity is saved in the object context. After calling the method of object context SaveChanges(), these values are saved in the database table.

##### Validation

Since the server side validation should be implemented in this layer I have created a validation interface in this layer called IValidation.cs. This class implements two valida-tion components as follows:

```
      List<string> ValidationSummary { get; set; }
      bool IsHavingValidInputs(params object[] inputs);      
```
Figure 19 Validation interface components

These two parameters are used by the business layer to implement the validation. In this layer we validate all the inputs from the user to enforce the security in the applica-tion. In the following code we can see the step by step implementation of input valida-tion;

```
   public List<string> ValidationSummary { get; set; }
```
Figure 20 Validation summary variable

This code is used to initialize the validation summary as a list. Then we should imple-ment the constructor for validation summary. The following code shows how it is done:

```
       public UserBusinessObjects(){ 
         userRepository = new GenericRepository<User>();
                        this.ValidationSummary = new List<String>(); 
         } 
```

Figure 21 Initialization of validation summary

After this we can use this summary for our input validation. For validation of the inputs certain validation rule should be enforced. According to those rules I am going to dis-cuss some of those methods which were used in the validation. The following piece of codes how to check required fields validation;

```
      private bool RequiredElementsInPlace(object[] inputs){ 
         foreach(var input in inputs){
          if (string.IsNullOrEmpty(input.ToString()))
                             return false;
                      }
                     return true;
         }
```

Figure 22 Required element validation method

In the above method all the inputs provided by the presentation layer are checked and if any of the value is null, returns false which triggers the error message and the CRUD operation is not executed. The following piece of code checks if the email input is in the correct format;

```
      private bool EmailIsInCorrectFormat(string p){
            if (p.Contains("@")){ 
            var halfEmail = p.Split('@')[1];
                          return halfEmail.Contains("."); 
            }
                        return false;
      }

```

Figure 23 Email format validation method 

The above method checks the validity of email input. All the validation methods are called from IsHavingValidInputs method. Then it decides whether to send those to DAL or not.
The following code shows how it is implemented:

```
      public bool IsHavingValidInputs(params object[] inputs){ 
             bool isValid = true;
             var requiredElements = new object[] { inputs[0], inputs[1], inputs[2], inputs[3], inputs[4] };
             if (!PasswordsMatch(inputs[1].ToString(), in-puts[2].ToString())){ 
               ValidationSummary.Add("Passwords do not match");
                               isValid = false; 
               }
                      if (!EmailIsInCorrectFormat(inputs[0].ToString())){ 
               ValidationSummary.Add("Email not in correct format");
                               isValid = false; 
               }            
                      if (!RequiredElementsInPlace(requiredElements)){
                ValidationSummary.Add("All fields are required");
                               isValid = false; 
               }
               return isValid;
      }

```

Figure 24 Input validation method

If the inputs from the presentation layer satisfy all these conditions then only these val-ues are sent to the DAL. The following piece of code shows how to do that;
```
   public bool RegisterUser(string email, string password, string password2, string firstName, string lastName, string gander, DateTime dob,string im-age){ 
            var validation = string.Empty;
                  if (this.IsHavingValidInputs(email, password,password2, firstName, lastName, gander, dob)){
                  if (!UserEmailExists(email)){
            userRepository.Add(new Model.User() { email = email, password = password, firstName = firstName, lastName = lastName, gender = gander, DOB=dob, image=image, userId = Guid.NewGuid() });
                         userRepository.SaveChanges();
                         return true;
                            }
                            else return false;
                        }
                        else
                        {
                            ValidationSummary.Add(validation);
                            return false;
                        }
        }

```
Figure 25 Validation in user registration method
 
This user registration will be successful if the method IsHavingValidInputs() returns true, otherwise it will ask user to make correction through the error message. 

#### Authentication

I have used user authentication process to provide access to the application on the ba-sis of username and password provided by the user. It is used in an application for the security and reliability of the application. If the application does not use the authentica-tion in an application, then the application is venerable to spoofing attacks, dictionary attack and session hijacking attack. The process of user authentication is implemented as follows:

```
      public bool UserExists(string userName,  string password){
            var exists = userRepository.Find(x => x.email.Equals(userName) && x.password.Equals(password));
            return exists.Count() > 0;
      }

```
Figure 26 User authentication method

In the above code this methods gets the username and password value from the presentation layer and it checks if the values exists in the database table. If they exist, it returns the count which is used by the presentation layer to provide access to the appli-cation. 

##### LINQ to Entities

For accessing data from DAL LINQ to Entity was used in the application development. Standard query operators are used to query IEnumerable<T> interface or IQueriable interface in LINQ. In the following piece of the code we can see how it is implemented;

```
   public IEnumerable<Task> GetLatestSixTask(string parent){
      return taskRepository.Find(x =>!string.IsNullOrEmpty(x.owner)).OrderByDescending(x => x.updateDate).Take(6);
           } 
```
Figure 27. LINQ query operators’ example.
The above method uses IEnumerable<Task> as LINQ query with standard query oper-ators like OrderByDescending() and Take().  LINQ query helped me a lot to deal with database in my application.

### Presentation Layer Development Process

The final step on development of the Ubuoy application was to build the presentation layer. It is responsible for the interaction between the user and the application. This layer is designed to respond to the user’s action in the UI. It contains UI components and the logic used to present information to the user. It defines the logical behavior and structure of the application. In layered system architecture it can access the method in BLL to provide interaction between the user and application. 

The project requirement was to provide the services to the users according to their loca-tion, skills, interest and setting made by the user. Presentation logic was designed to meet all these criteria. To generate the content for user dynamically was the only solu-tion for this problem. Due to this, all the classes in the presentation were implemented to generate the content of page dynamically.  

Profile page implementation is one of the examples of the dynamic content generation in this application. All the contents of the profile page are user specific which is generat-ed according to the information of the user stored in the database table. At the time of user login, when the login is successful a user session is created and all the required information of the user is stored in it. This session is used to generate the content. The following code shows how to create the session;

```
   Session["LoggedIn"] = true;
   Session["UserId"] = user.userId;
   Session["UserRole"] = user.Roles.SourceRoleName;

```

Figure 28 Assigning the values for session variables

In the above code a session is created and different values for the session variable are assigned. When the user successfully logs in, the UserId and UserRole is saved to pro-vide the services to the users according to his/her id and role. All of this information is saved in the session until the session is valid.

I have used this UserId value of session to retrieve user object from the database for presenting the user specific information in user interface. Due to this requirement I end-ed up in creating the whole UI dynamically. In this application development process I was busy in designing the back end of the application and my colleague was busy in developing the UI. At this point we were supposed to implement these two different types of programming to work together. There was one big problem of understanding these two different codes by the other person who has not written it. We had also prob-lems because I did not have good understanding in UI designing and Cascading Style Sheets (CSS) coding. Then we decided to work together for developing this part of ap-plication. Skype provided us an environment to work together by shearing each other’s screen. It was a great experience of coding together by helping each other. It helped us to continue our application development process by learning new things in each other’s code.

We started the implementation of UI and presentation layer from our profile page of the application. The presentation logic of profile page was to display user projects and mod-ule according to his involvement and the recent activity in application. The main prob-lem in this part of implementation was to generate exactly the same HyperText Markup Language (HTML) designed by UI designer from code behind part of aspx class. The code below shows the process of HTML code from code behind:

```
   HyperLink mainContent;
   mainContent.CssClass = "tile quadro double-vertical image border-color-LightGrey";
   mainContent.Attributes.Add("data-role", "tile-slider");
   mainContent.Attributes.Add("data-param-period", "3000");
   mainContent.Attributes.Add("data-param-direction", "left");
   mainContent.ID = "ProjectTrue"+count+"";
   mainContent.Attributes.Add("oncontextmenu", "return false; event.preventDefault();");

```       

Figure 29. Dynamic UI creation code example

In the above code I have defined CSS class for mainContent with its all attributes and the ID value to generate the HTML code which uses all these information during the runtime. When we run this code it generates the following code;

```
   <a id="PageRegionContent_ProjectTrue4" class="tile quadro double-vertical image border-color-LightGrey" on-click="event.preventDefault();" data-role="tile-slider" data-param-period="3000" data-param-direction="left" oncontextmenu="return false; event.preventDefault();"
```

Figure 30. HTML code generated by the application.

In the above code we can see that a hyperlink was created with the ID, class and attrib-ute’s information provided in the code behind. All the browsers use this HTML code to show the contents of the web page. Complete UI of Ubuoy application was developed from the code behind files.

All the data for the presentation logic was obtained by calling the method of business logic layer. The process of accessing method is shown in the following code;

```
    private Project _userProjects;
   var ProjObj = new BusinessLayer.ProjectBussinessObjects();
    _userProjects = ProjObj.GetProjectById(usersProjectId);     
```
Figure 31. Process of accessing the method of business layer.

In the above code project object and projectBusinessObjects class are initialized to call the method GetProjectById(). The value returned by the method is stored in _userProjects object. This object is used to provide data for the presentation layer.

I have used user controls to display different contents in a same web page according to the client’s selection. To achieve this feature, I have passed the control ID in query string whenever the client requests for a page. Using this control ID, proper page is se-lected and displayed for the user. This process is shown in the following code:

```
  var userControlName = Request.QueryString["formId"].ToString();
   switch (userControlName)
               {
                   case "AddProject":
                       addProject.Visible = true;
                       Page.Title = "Add a Project";
                       Label formHaderLabel = (La-bel)Master.FindControl("formHaderLabel");
                       formHaderLabel.Text = "| Add a Project";

                       break;

                   case "AddSkill":
                       addSkill.Visible = true;
                       Page.Title = "Add a Skill";
                       Label formHaderLabel2 = (La-bel)Master.FindControl("formHaderLabel");
                       formHaderLabel2.Text = "| Add a Skill";

                       break;

```
Figure 32. Selection of user control according to the value passed in query string.

In the above code value passed in the query string is obtained and checked by using switch. For example if AddProject is the value pass in the query string, then it satisfies the first case. This sets addProject user control to be visible, which displays the content of addProject in the web page.

Site navigation is also one of the important parts of presentation layer. All the pages of our web application are not accessible by the user without login. There are certain pag-es which contain sensitive information of the user. To secure these pages from the man in middle attack I have checked the session variable. If the session exists, the sensitive page like profile page is displayed and if the session does not exist, the user is redi-rected to the login page. The process of implementing this feature is shown below.

```
   protected void Page_Load(object sender, EventArgs e){
            if (Session["LoggedIn"] != null){
            //do stuff to load the page
            }else{
                            Response.Redirect("~/Login.aspx",false);
                        }
            }


```
Figure 33. Checking Session variable in page load method.

ASP.NET application lifecycle provides a page load method, which is called for loading the content of the page. In this method I have checked the value of session variable; if it is null, it redirects to the login page. If the session variable is not null, it means the ses-sion is created. Then user detail is checked and the profile page of that user is dis-played.  

Client side validation was done by using ASP.NET input validation controls like compare validation control, required field validation control, range validation control and regular expression validation control. For example I have used RegularExpressionValidation Control for checking the email format. In the property window of this validation control we can choose validation expression manually, which is shown in the following figure 34;

![img](https://github.com/dinesh2043/ASP.NET-Web-application/blob/master/img2.jpg)

Figure 34. Regular Expression dialog box.

From the above dialog box for email validation I chose the option Internet e-mail ad-dress for checking the format of the email address. After doing this I will get the ready-made method implementation for email validation. This validation control is hooked up with the email text box to check user input before the postback event is called. Client side validation reduces the server load and helps the user to fill in correct data in the input field.  

After implementing all these required features in the classes of presentation layer, our application was ready for testing and user review.
