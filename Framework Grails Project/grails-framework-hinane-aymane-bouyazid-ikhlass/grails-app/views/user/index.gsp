<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main"/>
    <g:set var="entityName" value="${message(code: 'user.label', default: 'User')}"/>
    <title><g:message code="default.list.label" args="[entityName]"/></title>
</head>

<body>




<div class="header" role="navigation">
    <ul>
        <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
        <li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
        <sec:ifAllGranted roles="ROLE_USER">
            <li> <a href="/userParcours">Afficher les parcours</a></li>
        </sec:ifAllGranted>
        <sec:ifAllGranted roles="ROLE_ADMIN">
            <li> <a href="/user/index">Gérer les utilisateurs</a></li>
        </sec:ifAllGranted>
        <li><a style="margin-left: auto" href="/logout">Logout</a></li>
    </ul>
</div>



<div role="main">


    <table class="user-table">

        <thead>
        <tr>
            <th class="sortable">Username</th>
            <th class="sortable">Email</th>
%{--            <th>Thumbnail</th>--}%
            <th>Role</th>
            <th></th>
        </tr>
        </thead>
        <tbody>
        <g:each in="${userList}" var="user">
            <tr>
                <td>
                    <g:link controller="user" action="show" id="${user.id}">
                        <g:fieldValue field="username" bean="${user}"/>
                    </g:link>
                    %{--                ${user.username}--}%
                </td>
                <td>
                    <g:fieldValue field="email" bean="${user}"/>
                </td>
%{--                <td>--}%
%{--                    <g:if test="${user.thumbnail}">--}%
%{--                        <img src="${grailsApplication.config.illustrations.url + user.thumbnail.name}"/>--}%
%{--                        <asset:image src="${user.thumbnail.name}"/>--}%
%{--                    </g:if>--}%
%{--                </td>--}%
                <td>
                    ${user.getAuthorities()*.authority.join(',')}
                </td>
                <td>
                    <g:form url="[controller: 'user', action: 'delete', id: user.id]" method="DELETE">
                        <button type="submit" class="delete" onclick="return confirm('Are you sure you want to delete this user?');">
                            Delete User
                        </button>
                    </g:form>

                </td>
            </tr>
        </g:each>

        </tbody>
    </table>

    <div class="pagination">
        <g:paginate total="${userCount ?: 0}"/>
    </div>


</div>



</body>
</html>