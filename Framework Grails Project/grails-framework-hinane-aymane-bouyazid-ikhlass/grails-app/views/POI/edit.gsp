<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main" />
    <g:set var="entityName" value="${message(code: 'POI.label', default: 'POI')}" />
    <title><g:message code="default.edit.label" args="[entityName]" /></title>
</head>
<body>


<div class="header" role="navigation">
    <ul>
        <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
        <li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
        <li> <a href="/userParcours">afficher mes parcours</a></li>
    </ul>
</div>

<div >
    <h1><g:message code="default.edit.label" args="[entityName]" /></h1>
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


%{--            <form action="/POI/update" method="post" enctype="multipart/form-data">--}%
    <g:form resource="${this.POI}" method="put" enctype="multipart/form-data">
        <input type="hidden" name="_method" value="PUT" id="_method" >
        <input type="hidden" name="version" value="0" id="version">
        <div class="fieldcontain required">
            <label for="name">Name
                <span class="required-indicator">*</span>
            </label><input type="text" name="name" value="cafe 1" required="" id="name">
        </div><div class="fieldcontain required">
        <label for="description">Description
            <span class="required-indicator">*</span>
        </label><input type="text" name="description" value="nn" required="" id="description">
    </div><div class="fieldcontain required">
        <label for="latitude">Latitude
            <span class="required-indicator">*</span>
        </label><input type="text" name="latitude" value="4.5" required="" id="latitude">
    </div><div class="fieldcontain required">
        <label for="longitude">Longitude
            <span class="required-indicator">*</span>
        </label><input type="text" name="longitude" value="2.77" required="" id="longitude">
    </div>

        <div class="fieldcontain">
            <label for="illustrationName">nom de l'image</label>
            <g:textField name="illustrationName"  />
        </div>
        <div class="fieldcontain">
            <label for="illustrationImg">Upload Image</label>
            <input type="file" name="illustrationImg" />
        </div>

    %{--                    <div class="fieldcontain">--}%
    %{--                    <label for="illustrationList">Illustration List</label><ul><li><a href="/illustration/show/7">com.mbds.parcours.Illustration : 7</a></li></ul><a href="/illustration/create?POI.id=1">Add Illustration</a>--}%
    %{--                </div>--}%






        <input style="margin-top: 100px;margin-left: 40px" class="save" type="submit" value="Update">


    </g:form>



</div>
</body>
</html>