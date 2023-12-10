<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main" />
    <g:set var="entityName" value="${message(code: 'parcours.label', default: 'Parcours')}" />
    <title><g:message code="default.edit.label" args="[entityName]" /></title>
</head>
<body>


<div class="header" role="navigation">
    <ul>
        <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
        <li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
    </ul>
</div>

<div  role="main">
<h1><g:message code="default.edit.label" args="[entityName]" /></h1>
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

<g:form resource="${this.parcours}" method="put"  enctype="multipart/form-data">


        <div class="fieldcontain">
            <label for="name">nom du parcours:</label>
            <g:textField name="name" value="${parcours?.name}" />
        </div>
        <div class="fieldcontain">
            <label for="description">Description du parcours:</label>
            <g:textArea name="description" value="${parcours?.description}" />
        </div>
        <div class="fieldcontain">
          <label >nouvelle illustration</label>
          <g:textField name="parcoursIllustrationName"  />
        </div>
        <div class="fieldcontain">
          <label >Upload Image</label>
          <input style="display: inline-block"  type="file" name="parcoursIllustrationImg" />
        </div>

    <br>


    <button type="button" class="collapsible"><h3>Ajouter un nouveau Point ( click ici )</h3></button>
    <div class="content">

            <div class="fieldcontain">
                <label for="illustrationName">Titre du point d'interet</label>
            <g:textField name="pointName" />
        </div>
        <div class="fieldcontain">
            <label for="illustrationName">Description du point d'interet</label>
            <g:textArea name="pointDescription"  />
        </div>
        <div class="fieldcontain">
            <label for="illustrationName">Longitude du point d'interet</label>
            <g:textField name="pointLongitude"  />
        </div>
        <div class="fieldcontain">
            <label for="illustrationName">Latitude du point d'interet</label>
            <g:textField name="pointLatitude"  />
        </div>

        <div class="fieldcontain">
            <label for="illustrationName">nom de l'image</label>
            <g:textField name="illustrationName"  />
        </div>
        <div class="fieldcontain">
            <label for="illustrationImg">Upload Image</label>
            <input style="display: inline-block"  type="file" name="illustrationImg" />
        </div>

    </div>




    <div class="fieldcontainrequired">
        <label for="author">Ajouter un modérateur
            <span class="required-indicator">*</span>
        </label>
        <input type="text"name="moderateur">
    </div>





        <input  class="btn-submit" type="submit" value="Save" />



</g:form>







</div>


</body>
</html>
