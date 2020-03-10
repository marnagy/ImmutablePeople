# Immutable People

-------------------

## Idea of solution

* Person -> Person<T> -> Student or Teacher

* Person will have specific methods close to WithName and WithPassword, which will only point to their actual virtual method in Person<T>
* Both Person **and** Person<T> are abstract classes to ensure all children need to have methods WithPassword and WithName implemented

## Needed classes:

- [x] Person (abstract)

- [x] Student

- [x] Teacher

### Person Methods

- [x] WithNameP
- [x] WithPasswordP

### GenericMethods

- [x] WithName
- [x] WithPassword

### Student methods

- [x] WithDateEnrolled
- [x] override Equals
### Teacher methods
- [x] WithCoursesHeld
- [x] override Equals

### Extension methods for List of People

- [x] PrintAll (not tested)
- [x] WithPasswordResetByFirstName (not tested)