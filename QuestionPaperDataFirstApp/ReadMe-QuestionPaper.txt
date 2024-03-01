Steps to follow
----------------

1. First run the script file.

2. Open the project in the Visual Studio.

3. Run the project



Key Points
-----------

1. I have used session to store logged in user data. As session stores data for only 20 minutes, if you take more than 20 minutes then it may generate an error.
2. In this project only those data will be visible to student and teacher which are created or attempted by themselves. Not other teacher or students data will be visible to perticular student or teacher.
3. Admin has all the rights in this project.


Admin rights
------------

1. Register new user (As only admin can register new user, user can not register and can not update his/her details by him or herself).
2. Edit, update or view user details (Only admin can register and update user details. Student and teacher can not update their profile themselves.)
3. Can View all the papers created by teachers.
4. Can update, view and delete papers.
5. Can approved, or reject papers.
6. Can add questions to paper and also update, view or modify exist in the perticular paper.
7. Can view all the exams given by students.


Teacher rights
---------------

1. Teacher will be able to create  new paper and add questions to that paper. (All the papers created by this teacher will be visible to them, not papers created by other teacher)
2. Can update, delete or view paper details and its related questions


Student rights
----------------

1. Student will only be able to view and attempt exam.
2. Student can view given exams by him/her.


