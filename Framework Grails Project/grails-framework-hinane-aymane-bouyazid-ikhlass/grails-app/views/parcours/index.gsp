<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main" />
    <g:set var="entityName" value="${message(code: 'parcours.label', default: 'Parcours')}" />
    <title><g:message code="default.list.label" args="[entityName]" /></title>
</head>



<body>

%{--<a href="#list-parcours" class="skip" tabindex="-1"><g:message code="default.link.skip.label" default="Skip to content&hellip;"/></a>--}%

<div class="container">

    <div class="header" role="navigation">
        <ul>
            <li><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></li>
            <li><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></li>
            <sec:ifAllGranted roles="ROLE_USER">
                <li> <a href="/userParcours">Afficher mes parcours</a></li>
            </sec:ifAllGranted>
            <sec:ifAllGranted roles="ROLE_ADMIN">
                <li> <a href="/user/index">Gérer les utilisateurs</a></li>
            </sec:ifAllGranted>
            <li><a style="margin-left: auto" href="/logout">Logout</a></li>
        </ul>
    </div>

    <div class="container-parcours">

        <div class="container-nav">
            <g:each in="${parcoursList}" var="parcours">
                <div class="parcours" data-parcours-id="${parcours.id}">
                    <h3>${parcours.name}</h3>
                    <img width="350" height="200px" src="${assetPath(src:'avatar_'+parcours.illustrationList[0].id+'.jpg')}" >
                </div>
            </g:each>
        </div>

        <div class="container-content">
            <g:each in="${parcoursList}" var="parcours">
                <div class="content" style="background-color: #ffffff;" data-parcours-id="${parcours.id}">
                    <h2>Author: ${parcours.author.username}</h2>
                    <h5>${parcours.description}</h5>
                    <div class="img-container" >
                        <g:each in="${parcours.illustrationList}" var="illustration">
                            <img width="300" height="200px"  src="${resource(dir: 'images', file:'avatar_' + illustration.id + '.jpg')}" alt="Grails"/>
                        </g:each>
                    </div>

                    <% if(isAdmin){ %>
                    <a href="/parcours/edit/${parcours.id}">
                        <button class="btn-update" style="display: inline-block"> Editer le parcours</button>
                    </a>
                    <g:form  style="display: inline-block" url="[controller: 'parcours', action: 'delete', id: parcours.id]" method="DELETE">
                        <button style="display: inline-block"  class="btn-del" type="submit" class="delete" onclick="return confirm('Are you sure you want to delete this parcours?');">
                            Supprimer Parcours
                        </button>
                    </g:form>
                    <% } %>
                    %{--                       <sec:ifAllGranted roles="ROLE_USER"></sec:ifAllGranted>--}%
                    <div class="point-container">
                        <h2 style="margin-top: 30px">Listes des Points</h2>
                        <g:each in="${parcours.poiList}" var="poi">
                            <h4 style="margin-top: 20px">${poi.name}</h4>
                            <div class="img-container">
                                <g:each in="${poi.illustrationList}" var="illustration">
                                    <img width="300" height="200px"  src="${resource(dir: 'images', file:'avatar_' + illustration.id + '.jpg')}" alt="Grails"/>
                                </g:each>
                            </div>
                            <% if(isAdmin){ %>
                            <a href="/POI/edit/${poi.id}">
                                <button class="btn-update"> modifier le poi</button>
                            </a>
                            <g:form  style="display: inline-block" url="[controller: 'POI', action: 'delete', id: poi.id]" method="DELETE">
                                <button style="display: inline-block"  class="btn-del" type="submit" class="delete" onclick="return confirm('Are you sure you want to delete this parcours?');">
                                    Supprimer POI
                                </button>
                            </g:form>
                            <% } %>
                        %{--                               <sec:ifAllGranted roles="ROLE_USER"></sec:ifAllGranted>--}%
                        </g:each>
                    </div>
                </div>
            </g:each>
        </div>
    </div>

    <div class="pagination">
        <g:paginate total="${parcoursCount ?: 0}" />
    </div>



</div>




</body>
</html>
