Custom-shaped ViewModel classes 
==================================

The MVC pattern makes it possible to efficiently manage common functionality centred around creating, deleting, updating and deleting  content withing a structured application; perfect for a management system. .Net's MVC framework implements this pattern with direct entity to mapping between models and display. 

However, direct mapping of real database entities is not always desirable. Using class mappings directly exposes a model object and has security implications; how much end users know about how data is stored in the database leaves systems open to SQL injection attacks.

Supporting direct model mapping from properties is also a convenient approach and works well in scenarios where the rendering desired for views and UIs corresponds to data objects themselves; but this also is not always the case.

One common approach to represent data or accept data input in different forms  is to implement a "custom-shaped ViewModel class" which acts as an interface between the real data, at a system level, and the data abstrations that are more effective for user interfaces.

This way the view can be completely independent of the database while still being strictly typed and benefiting from .Net's useful validation and security features. 

Additional benefits, and the main ones desired for this system that this pattern facilitated, were:

* Request or present data belonging to multiple entities in a user-meningful context.
* Process data from users in a context that makes sense to them, not how the system understands it.
* Produce a consistent and strucured format for output for to machine users (GeoJson API)

Custom-shaped ViewModel classes are a less disscussed implementation pattern in .Net MVC but they add significant advantages as described above. 