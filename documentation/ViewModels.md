Custom-shaped ViewModel classes [^1]
==================================

From Nerd Dinner: In the scenario above, our DinnerFormViewModel class directly exposes the Dinner model object as a property, along with a supporting SelectList model property.  This approach works fine for scenarios where the HTML UI we want to create within our view template corresponds relatively closely to our domain model objects.

For scenarios where this isn't the case, one option that you can use is to create a custom-shaped ViewModel class whose object model is more optimized for consumption by the view – and which might look completely different from the underlying domain model object.  For example, it could potentially expose different property names and/or aggregate properties collected from multiple model objects. 

Custom-shaped ViewModel classes can be used both to pass data from controllers to views to render, as well as to help handle form data posted back to a controller's action method.  For this later scenario, you might have the action method update a ViewModel object with the form-posted data, and then use the ViewModel instance to map or retrieve an actual domain model object. 

Custom-shaped ViewModel classes can provide a great deal of flexibility, and are something to investigate any time you find the rendering code within your view templates or the form-posting code inside your action methods starting to get too complicated.  This is often a sign that your domain models don't cleanly correspond to the UI you are generating, and that an intermediate custom-shaped ViewModel class can help.

What is AutoMapper?
=======================

AutoMapper is an object-object mapper. Object-object mapping works by transforming an input object of one type into an output object of a different type. Mapping can occur in many places in an application, but mostly in the boundaries between layers, such as between the UI/Domain layers, or Service/Domain layers. Concerns of one layer often conflict with concerns in another, so object-object mapping leads to segregated models, where concerns for each layer can affect only types in that layer.

Domain Transfer Object (DTO)
===================================

This is a term for an object that is just used to transfer data to an entity. Our ViewModels are not technically DTO's because they would have methods.


[^1]: http://nerddinnerbook.s3.amazonaws.com/Part6.htm