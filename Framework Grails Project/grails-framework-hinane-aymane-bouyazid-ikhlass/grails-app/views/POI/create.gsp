<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main" />
    <g:set var="entityName" value="${message(code: 'POI.label', default: 'POI')}" />
    <title><g:message code="default.create.label" args="[entityName]" /></title>
</head>
<body>
<a href="#create-POI" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>
<div class="nav" role="navigation">
    <ul>
        <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
        <li><g:link class="list" action="index"><g:message code="default.list.label" args="[entityName]" /></g:link></li>
    </ul>
</div>
<div id="create-POI" class="content scaffold-create" role="main">
    <h1><g:message code="default.create.label" args="[entityName]" /></h1>
    <g:if test="${flash.message}">
        <div class="message" role="status">${flash.message}</div>
    </g:if>
    <g:hasErrors bean="${this.POI}">
        <ul class="errors" role="alert">
            <g:eachError bean="${this.POI}" var="error">
                <li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
            </g:eachError>
        </ul>
    </g:hasErrors>

    <form action="/POI/save" method="post">
        <fieldset class="form">
            <div class="fieldcontain required">
                <label for="name">Name
                    <span class="required-indicator">*</span>
                </label><input type="text" name="name" value="" required="" id="name">
            </div><div class="fieldcontain required">
            <label for="description">Description
                <span class="required-indicator">*</span>
            </label><input type="text" name="description" value="" required="" id="description">
        </div><div class="fieldcontain required">
            <label for="latitude">Latitude
                <span class="required-indicator">*</span>
            </label><input type="number decimal" name="latitude" value="" required="" id="latitude">
        </div><div class="fieldcontain required">
            <label for="longitude">Longitude
                <span class="required-indicator">*</span>
            </label><input type="number decimal" name="longitude" value="" required="" id="longitude">
        </div><div class="fieldcontain">
            <label for="illustrationList">Illustration List</label><ul></ul><a href="/illustration/create?POI.id=">Add Illustration</a>
        </div>
        </fieldset>
        <fieldset class="buttons">
            <input type="submit" name="create" class="save" value="Create" id="create">
        </fieldset>
    </form>

</div>
</body>
</html>
