
Identified new things & their summary

CQRS(Command Query Responsibility Segregation)
-----------------------------------------------------
	1)Its a architectural pattern
	2)Seperates read & write operations

	PRO(s)
		Performance: as read/write handled seperately, you can denormalize data for read to improve query speed.
		Scalability: optimized for high volume read operations without affecting write performance
		Flexibility: differenct technologies can be used for read and writes. 
					relational for write & document database for read.
		Security: strict security on command. while keeping query side more open
		Supports event sourcing: naturally supports event sourcing

	CON(s)
		Increased complexity
		Eventual consistency
		Learning curve
		Potential overkill
		Data duplication
		Increased development time

MediatR
	-Its a in-process messaging library
	-It helps to implement CQRS pattern
	-It helps to decouple the communication between objects
	-Supports request/response, notifications, pipelines, and more


Feature folder: Vertical slice architecture
---------------------------------------------------------
	It would organize features by folder
	It would make easier to locate & maintain code related to specific feature

	PRO(s)
		Code organization
		Readability
		Maintainability especially in larger projects


Record(type)
--------------
	Its recommended to use records to define (D)ata (T)ransfer (O)bjects, 
	Immutable by default!
		Cannot be changed, once its created
	Records cannot be extended.
	Records cannot have behaviours.
	Its nothing but a data carrier.


