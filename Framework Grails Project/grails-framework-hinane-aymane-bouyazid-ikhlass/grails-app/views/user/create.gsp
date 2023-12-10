<!DOCTYPE html>
<html>
    <head>
        <meta name="layout" content="main" />
        <g:set var="entityName" value="${message(code: 'user.label', default: 'User')}" />
        <title><g:message code="default.create.label" args="[entityName]" /></title>
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
            <h1><g:message code="default.create.label" args="[entityName]" /></h1>
            <g:if test="${flash.message}">
            <div class="message" role="status">${flash.message}</div>
            </g:if>
            <g:hasErrors bean="${this.user}">
            <ul class="errors" role="alert">
                <g:eachError bean="${this.user}" var="error">
                <li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
                </g:eachError>
            </ul>
            </g:hasErrors>


            <form class="form" action="/user/save" method="post">

                    <div class="fieldcontain required">
                        <label for="password">Password
                            <span class="required-indicator">*</span>
                        </label><input type="password" name="password" required="" value="" id="password">
                    </div><div class="fieldcontain required">
                    <label for="username">Username
                        <span class="required-indicator">*</span>
                    </label><input type="text" name="username" value="" required="" id="username">
                </div><div class="fieldcontain required">
                    <label for="email">Email
                        <span class="required-indicator">*</span>
                    </label><input type="email" name="email" value="" required="" id="email">
                <div class="fieldcontain">
                    <label for="passwordExpired">Password Expired</label><input type="hidden" name="_passwordExpired"><input type="checkbox" name="passwordExpired" id="passwordExpired">
                </div><div class="fieldcontain">
                    <label for="accountLocked">Account Locked</label><input type="hidden" name="_accountLocked"><input type="checkbox" name="accountLocked" id="accountLocked">
                </div><div class="fieldcontain">
                    <label for="accountExpired">Account Expired</label><input type="hidden" name="_accountExpired"><input type="checkbox" name="accountExpired" id="accountExpired">
                </div><div class="fieldcontain">
                    <label for="enabled">Enabled</label><input type="hidden" name="_enabled"><input type="checkbox" name="enabled" checked="checked" id="enabled">
                </div>

                    <input type="submit" name="create" class="save" value="Create" id="create">
            </form>




</div>
</body>
</html>
