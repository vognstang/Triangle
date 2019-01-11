# Triangle
Basic Triangle Api

.Net Core, Visual Studio Code

Design Considerations

Programming Model:  
I decided to go with an immutable design and a semi-fluent style code structure, in an effort to put down almost as many constraints as possible. 

Exceptions and Error handeling:  
I decided to leave in the possibility of having an invalid state, instead of throwing an exception. It can be argued that the domain may throw exceptions when there is a very simpel use case for the domain. But to leave in some flexibility I decided to let the caller decide whether to throw or not.  

Distinct and Performance:  
I considered utilizing a struct for the Triangle, because the footprint is below 16 bytes and that the value-equality comes out of the box, I also had a faint idea that it can be faster in certain cases. In this case the struct proberly would end up on the heap, due to storage. So I went with a class and implemented value-equality. Also I decided to store all valid Triangles no matter if there are duplicates and then create a distinct list on query. It could be considered to remove duplicates when adding, given a "real" storage this would requirer a query to the datastore, so I decided to just write everything thats valid.

Dto/Contracts:  
The controller ought to have a contract, especially in the case that we have external dependants. 

http://(+):port/api/triangle  
http://(+):port/swagger  

https://github.com/vognstang/Triangle