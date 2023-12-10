<%--
  Created by IntelliJ IDEA.
  User: aymanehinane
  Date: 5/11/2023
  Time: 20:25
--%>

<%@ page contentType="text/html;charset=UTF-8" %>
<html>
<head>
    <title></title>
</head>

<body>
<h1>Registration Page</h1>
<form action="${createLink(controller: 'registration', action: 'save')}" method="post">
    <!-- Registration form fields go here -->
    <label for="username">Username:</label>
    <input type="text" name="username" id="username" required>
    <br>
    <label for "password">Password:</label>
    <input type="password" name="password" id="password" required>
    <br>
    <input type="submit" value="Save">
</form>

</body>
</html>