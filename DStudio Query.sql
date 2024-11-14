use [DStudio.Calmplete]

--Write a query to select all users with unconfirmed emails;;
select *
from Users
where EmailConfirmed = 0

update Users
set EmailConfirmed = 0
where UserId in ('4A7B05F2-AA55-45A4-608F-08DBCE615228', '75B0E499-C474-4BAF-560A-08DBCF2153E3', '8DA3C5D5-C608-48DD-560C-08DBCF2153E3')
--Write a query to get count of users with unconfirmed emails;
select count(UserId) as [Number of unverified postal addresses]
from Users
where EmailConfirmed = 0
--Write a query to get all uncompleted tasks (todos);-Íàïèøèòå çàïðîñ äëÿ ïîëó÷åíèÿ âñåõ íåçàâåðøåííûõ çàäà÷ (todos);
select *
from Todos
where IsCompleted = 0
--Write a query to get users who have at least 3 uncompleted tasks.
select u.UserId, u.UserName, u.Email, count(u.UserId) as [Number not completed tasks]
from Users as u
join Todos as td on u.UserId = td.UserId
where td.IsCompleted = 0
group by u.UserId, u.UserName, u.Email

