Need for validation
	Data integrity - prevent incorrect or incomplete data saved into database
	Security - prevents from security vulnerabilities like 
		- SQL injection
		- XSS-Cross site scripting
		- CSRF - cross-site request forgery
	User experience - provides immediate feedback to the user about the correctness of the input
	Business logic - ensures data meets the requirement of the application

Why Data-annotations not suitable always?
	Its not a good approach to combine model & validation logic
	This violates Seperation of Concerns principle

Why Fluent validation?
	Its a library that allows you to define validation rules in a separate class
	Its a standalone library that can be used with any .NET project
	Its a flexible library that allows you to define complex validation rules
	Its a powerful library that allows you to define custom validation rules
	Its a library that allows you to define validation rules in a strongly typed manner

Approaches for Fluent validation
	Manual validation(Recommended)
	Auto validation using ASP.NET Core pipeline, but this is deprecated and no longer supported by FluentValidation
	Validation using filters - requires external package

Capabilities of Fluent validation
	-Custom validation messages	
	-Validation rules
		- NotEmpty
		- NotNull
		- Length
		- InclusiveBetween
		- ExclusiveBetween
		- GreaterThan
		- GreaterThanOrEqual
		- LessThan
		- LessThanOrEqual
		- Equal
		- NotEqual
		- Email
		- CreditCard
		- Phone
		- Matches
		- Must
		- Custom
		- RegularExpression
	-Overriding property name
	-Grouping validation rules
	-Chaining validation rules
	-Custom validation rules
	-Conditional validation rules
	-Validation rules for collections
	-Validation rules for child objects
	-Stop on first failure
