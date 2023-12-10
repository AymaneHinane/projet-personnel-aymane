<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main" />
    <g:set var="entityName" value="${message(code: 'parcours.label', default: 'Parcours')}" />
    <title><g:message code="default.create.label" args="[entityName]" /></title>
</head>
<body>



<div class="header" role="navigation">
    <ul>
        <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
        <li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
    </ul>
</div>


<div id="create-parcours"  role="main">
    <h1><g:message code="default.create.label" args="[entityName]" /></h1>
    <g:if test="${flash.message}">
        <div class="message" role="status">${flash.message}</div>
    </g:if>
    <g:hasErrors bean="${this.parcours}">
        <ul class="errors" role="alert">
            <g:eachError bean="${this.parcours}" var="error">
                <li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
            </g:eachError>
        </ul>
    </g:hasErrors>




    <form action="/parcours/save" method="post"  enctype="multipart/form-data">


            <div class="fieldcontain required">
                <label for="name">Name
                    <span class="required-indicator">*</span>
                </label><input type="text" name="name" value="" required="" id="name">
            </div>

            <div class="fieldcontain required">
                <label for="description">Description
                    <span class="required-indicator">*</span>
                </label><input type="text" name="description" value="" required="" id="description">
            </div>

            <div class="fieldcontain">
                <label for="illustrationName">nom de l'image</label>
                <g:textField name="illustrationName"  />
            </div>
            <div class="fieldcontain">
                <label for="illustrationImg">Upload Image</label>
                <input style="display: inline-block "type="file" name="illustrationImg" />
            </div>







            <input  class="btn-submit" type="submit" name="create" class="save" value="Create" id="create">
    </form>


</div>
</body>
</html>
