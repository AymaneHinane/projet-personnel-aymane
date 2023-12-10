<!doctype html>
<%--<html>
<head>
    <meta name="layout" content="main"/>
    <title>Welcome to Grails</title>
</head>
<body>
    <content tag="nav">
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Application Status <span class="caret"></span></a>
            <ul class="dropdown-menu">
                <li><a href="#">Environment: ${grails.util.Environment.current.name}</a></li>
                <li><a href="#">App profile: ${grailsApplication.config.grails?.profile}</a></li>
                <li><a href="#">App version:
                    <g:meta name="info.app.version"/></a>
                </li>
                <li role="separator" class="divider"></li>
                <li><a href="#">Grails version:
                    <g:meta name="info.app.grailsVersion"/></a>
                </li>
                <li><a href="#">Groovy version: ${GroovySystem.getVersion()}</a></li>
                <li><a href="#">JVM version: ${System.getProperty('java.version')}</a></li>
                <li role="separator" class="divider"></li>
                <li><a href="#">Reloading active: ${grails.util.Environment.reloadingAgentEnabled}</a></li>
            </ul>
        </li>
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Artefacts <span class="caret"></span></a>
            <ul class="dropdown-menu">
                <li><a href="#">Controllers: ${grailsApplication.controllerClasses.size()}</a></li>
                <li><a href="#">Domains: ${grailsApplication.domainClasses.size()}</a></li>
                <li><a href="#">Services: ${grailsApplication.serviceClasses.size()}</a></li>
                <li><a href="#">Tag Libraries: ${grailsApplication.tagLibClasses.size()}</a></li>
            </ul>
        </li>
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Installed Plugins <span class="caret"></span></a>
            <ul class="dropdown-menu">
                <g:each var="plugin" in="${applicationContext.getBean('pluginManager').allPlugins}">
                    <li><a href="#">${plugin.name} - ${plugin.version}</a></li>
                </g:each>
            </ul>
        </li>
    </content>

    <div class="svg" role="presentation">
        <div class="grails-logo-container">
            <asset:image src="grails-cupsonly-logo-white.svg" class="grails-logo"/>
        </div>
    </div>

    <div id="content" role="main">
        <section class="row colset-2-its">
            <h1>Welcome to Grails</h1>

            <p>
                Congratulations, you have successfully started your first Grails application! At the moment
                this is the default page, feel free to modify it to either redirect to a controller or display
                whatever content you may choose. Below is a list of controllers that are currently deployed in
                this application, click on each to execute its default action:
            </p>

            <div id="controllers" role="navigation">
                <h2>Available Controllers:</h2>
                <ul>
                    <g:each var="c" in="${grailsApplication.controllerClasses.sort { it.fullName } }">
                        <li class="controller">
                            <g:link controller="${c.logicalPropertyName}">${c.fullName}</g:link>
                        </li>
                    </g:each>
                </ul>
            </div>
        </section>
    </div>

</body>
</html>
--%>


<html lang="en" class="no-js"><head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>
    Welcome to Grails
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/x-ico" href="/assets/favicon.ico">

    <link rel="stylesheet" href="/assets/bootstrap.css?compile=false">
    <link rel="stylesheet" href="/assets/grails.css?compile=false">
    <link rel="stylesheet" href="/assets/main.css?compile=false">
    <link rel="stylesheet" href="/assets/mobile.css?compile=false">
    <link rel="stylesheet" href="/assets/application.css?compile=false">



    <meta name="layout" content="main">


    <style type="text/css">@font-face { font-family: Roboto; src: url("chrome-extension://mcgbeeipkmelnpldkobichboakdfaeon/css/Roboto-Regular.ttf"); }</style></head>
<body>

<div class="navbar navbar-default navbar-static-top" role="navigation">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/#">
                <img src="/assets/logo.jpg" alt="Grails Logo">
            </a>
        </div>
        <div class="navbar-collapse collapse" aria-expanded="false" style="height: 0.8px;">
            <ul class="nav navbar-nav navbar-right">

<!--
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Application Status <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="#">Environment: development</a></li>
                        <li><a href="#">App profile: web</a></li>
                        <li><a href="#">App version:
                        0.1</a>
                        </li>
                        <li role="separator" class="divider"></li>
                        <li><a href="#">Grails version:
                        3.3.8</a>
                        </li>
                        <li><a href="#">Groovy version: 2.4.15</a></li>
                        <li><a href="#">JVM version: 1.8.0_221</a></li>
                        <li role="separator" class="divider"></li>
                        <li><a href="#">Reloading active: true</a></li>
                    </ul>
                </li>-->
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Artefacts <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a href="#">Controllers: 7</a></li>
                        <li><a href="#">Domains: 7</a></li>
                        <li><a href="#">Services: 2</a></li>
                        <li><a href="#">Tag Libraries: 15</a></li>
                    </ul>
                </li>
                <!-- <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Installed Plugins <span class="caret"></span></a>
                    <ul class="dropdown-menu">

                        <li><a href="#">core - 3.3.8</a></li>

                        <li><a href="#">dataSource - 3.3.8</a></li>

                        <li><a href="#">i18n - 3.3.8</a></li>

                        <li><a href="#">fields - 2.2.8</a></li>

                        <li><a href="#">codecs - 3.3.8</a></li>

                        <li><a href="#">restResponder - 3.3.8</a></li>

                        <li><a href="#">eventBus - 3.3.2</a></li>

                        <li><a href="#">dataBinding - 3.3.8</a></li>

                        <li><a href="#">controllers - 3.3.8</a></li>

                        <li><a href="#">urlMappings - 3.3.8</a></li>

                        <li><a href="#">groovyPages - 3.3.1</a></li>

                        <li><a href="#">scaffolding - 3.4.1</a></li>

                        <li><a href="#">assetPipeline - 2.14.8</a></li>

                        <li><a href="#">domainClass - 3.3.8</a></li>

                        <li><a href="#">converters - 3.3.8</a></li>

                        <li><a href="#">controllersAsync - 3.3.2</a></li>

                        <li><a href="#">mimeTypes - 3.3.8</a></li>

                        <li><a href="#">hibernate - 6.1.10</a></li>

                        <li><a href="#">services - 3.3.8</a></li>

                        <li><a href="#">cache - 4.0.0</a></li>

                        <li><a href="#">interceptors - 3.3.8</a></li>

                        <li><a href="#">springSecurityCore - 3.2.3</a></li>

                    </ul>
                </li> -->
                <li><a href="/login">Login</a></li>
            </ul>
        </div>
    </div>
</div>




<div class="svg" role="presentation">
    <div class="grails-logo-container">
        <img src="/assets/logo.jpg" class="grails-logo">
    </div>
</div>

<div id="content" role="main">
    <section class="row colset-2-its">
        <h1>Welcome to Course</h1>

        <p>
            Découvrez notre application pour créer des itinéraires et explorer des points d'intérêt passionnants.
            Partagez vos aventures avec d'autres utilisateurs et trouvez de nouvelles destinations à explorer.
            Préparez-vous à des découvertes uniques et à des voyages inoubliables.
            Rejoignez notre communauté d'explorateurs dès aujourd'hui
        </p>

        <div id="controllers" role="navigation">
            <h2>Available Controllers:</h2>
            <ul>

                <li class="controller">
                    <a href="/illustration/index">com.mbds.parcours.IllustrationController</a>
                </li>

                <li class="controller">
                    <a href="/POI/index">com.mbds.parcours.POIController</a>
                </li>

                <li class="controller">
                    <a href="/parcours/index">com.mbds.parcours.ParcoursController</a>
                </li>

                <li class="controller">
                    <a href="/test/test">com.mbds.parcours.TestController</a>
                </li>

                <li class="controller">
                    <a href="/user/index">com.mbds.parcours.UserController</a>
                </li>

                <li class="controller">
                    <a href="/login/index">grails.plugin.springsecurity.LoginController</a>
                </li>

                <li class="controller">
                    <a href="/logout/index">grails.plugin.springsecurity.LogoutController</a>
                </li>

            </ul>
        </div>
    </section>
</div>



<div class="footer" role="contentinfo"></div>

<div id="spinner" class="spinner" style="display:none;">
    Loading…
</div>

<script type="text/javascript" src="/assets/jquery-2.2.0.min.js?compile=false"></script>
<script type="text/javascript" src="/assets/bootstrap.js?compile=false"></script>
<script type="text/javascript" src="/assets/application.js?compile=false"></script>




<script>
    function returnCommentSymbol(language = "javascript") {
        const languageObject = {
            bat: "@REM",
            c: "//",
            csharp: "//",
            cpp: "//",
            closure: ";;",
            coffeescript: "#",
            dockercompose: "#",
            css: "/*DELIMITER*/",
            "cuda-cpp": "//",
            dart: "//",
            diff: "#",
            dockerfile: "#",
            fsharp: "//",
            "git-commit": "//",
            "git-rebase": "#",
            go: "//",
            groovy: "//",
            handlebars: "{{!--DELIMITER--}}",
            hlsl: "//",
            html: "<!--DELIMITER-->",
            ignore: "#",
            ini: ";",
            java: "//",
            javascript: "//",
            javascriptreact: "//",
            json: "//",
            jsonc: "//",
            julia: "#",
            latex: "%",
            less: "//",
            lua: "--",
            makefile: "#",
            markdown: "<!--DELIMITER-->",
            "objective-c": "//",
            "objective-cpp": "//",
            perl: "#",
            perl6: "#",
            php: "<!--DELIMITER-->",
            powershell: "#",
            properties: ";",
            jade: "//-",
            python: "#",
            r: "#",
            razor: "<!--DELIMITER-->",
            restructuredtext: "..",
            ruby: "#",
            rust: "//",
            scss: "//",
            shaderlab: "//",
            shellscript: "#",
            sql: "--",
            svg: "<!--DELIMITER-->",
            swift: "//",
            tex: "%",
            typescript: "//",
            typescriptreact: "//",
            vb: "'",
            xml: "<!--DELIMITER-->",
            xsl: "<!--DELIMITER-->",
            yaml: "#"
        }
        if(!languageObject[language]){
            return languageObject["python"].split("DELIMITER")
        }
        return languageObject[language].split("DELIMITER")
    }
    var savedChPos = 0
    var returnedSuggestion = ''
    let editor, doc, cursor, line, pos
    pos = {line: 0, ch: 0}
    var suggestionsStatus = false
    var docLang = "python"
    var suggestionDisplayed = false
    var isReturningSuggestion = false
    document.addEventListener("keydown", (event) => {
        setTimeout(()=>{
            editor = event.target.closest('.CodeMirror');
            if (editor){
                const codeEditor = editor.CodeMirror
                if(!editor.classList.contains("added-tab-function")){
                    editor.classList.add("added-tab-function")
                    codeEditor.removeKeyMap("Tab")
                    codeEditor.setOption("extraKeys", {Tab: (cm)=>{

                            if(returnedSuggestion){
                                acceptTab(returnedSuggestion)
                            }
                            else{
                                cm.execCommand("defaultTab")
                            }
                        }})
                }
                doc = editor.CodeMirror.getDoc()
                cursor = doc.getCursor()
                line = doc.getLine(cursor.line)
                pos = {line: cursor.line, ch: line.length}

                if(cursor.ch > 0){
                    savedChPos = cursor.ch
                }

                const fileLang = doc.getMode().name
                docLang = fileLang
                const commentSymbol = returnCommentSymbol(fileLang)
                if (event.key == "?"){
                    var lastLine = line
                    lastLine = lastLine.slice(0, savedChPos - 1)

                    if(lastLine.trim().startsWith(commentSymbol[0])){
                        if(fileLang !== "null"){
                            lastLine += " "+ fileLang
                        }

                        lastLine = lastLine.split(commentSymbol[0])[1]
                        window.postMessage({source: 'getQuery', payload: { data: lastLine } } )
                        isReturningSuggestion = true
                        displayGrey("\nBlackbox loading...")
                    }
                }else if(event.key === "Enter" && suggestionsStatus && !isReturningSuggestion){
                    var query = doc.getRange({ line: Math.max(0,cursor.line-50), ch: 0 }, { line: cursor.line, ch: line.length })
                    window.postMessage({source: 'getSuggestion', payload: { data: query, language: docLang, cursorPos: pos } } )
                    displayGrey("Blackbox loading...")
                }else if(event.key === "ArrowRight" && returnedSuggestion){
                    acceptTab(returnedSuggestion)
                }else if(event.key === "Enter" && isReturningSuggestion){
                    displayGrey("\nBlackbox loading...")
                }else if(event.key === "Escape"){
                    displayGrey("")
                }
            }
        }, 0)
    })

    function acceptTab(text){
        if (suggestionDisplayed){
            displayGrey("")
            doc.replaceRange(text, pos)
            returnedSuggestion = ""
            updateSuggestionStatus(false)
        }
    }
    function acceptSuggestion(text){
        displayGrey("")
        doc.replaceRange(text, pos)
        returnedSuggestion = ""
        updateSuggestionStatus(false)
    }
    function displayGrey(text){
        if(!text){
            document.querySelector(".blackbox-suggestion").remove()
            return
        }
        var el = document.querySelector(".blackbox-suggestion")
        if(!el){
            el = document.createElement('span')
            el.classList.add("blackbox-suggestion")
            el.style = 'color:grey'
            el.innerText = text
        }
        else{
            el.innerText = text
        }

        var lineIndex = pos.line;
        editor.getElementsByClassName('CodeMirror-line')[lineIndex].appendChild(el)
    }
    function updateSuggestionStatus(s){
        suggestionDisplayed = s
        window.postMessage({source: 'updateSuggestionStatus', status: suggestionDisplayed, suggestion: returnedSuggestion})
    }
    window.addEventListener('message', (event)=>{
        if (event.source !== window ) return
        if (event.data.source == 'return'){
            isReturningSuggestion = false
            const formattedCode = formatCode(event.data.payload.data)
            returnedSuggestion = formattedCode
            displayGrey(formattedCode)
            updateSuggestionStatus(true)
        }
        if(event.data.source == 'suggestReturn'){
            const prePos = event.data.payload.cursorPos
            if(pos.line == prePos.line && pos.ch == prePos.ch){
                returnedSuggestion = event.data.payload.data
                displayGrey(event.data.payload.data)
                updateSuggestionStatus(true)
            }
            else{
                displayGrey()
            }
        }
        if(event.data.source == 'codeSearchReturn'){
            isReturningSuggestion = false
            displayGrey()
        }
        if(event.data.source == 'suggestionsStatus'){
            suggestionsStatus = event.data.payload.enabled
        }
        if(event.data.source == 'acceptSuggestion'){

            acceptSuggestion(event.data.suggestion)
        }
    })
    document.addEventListener("keyup", function(){
        returnedSuggestion = ""
        updateSuggestionStatus(false)
    })
    function formatCode(data) {
        if (Array.isArray(data)) {
            var finalCode = ""
            var pairs = []

            const commentSymbol = returnCommentSymbol(docLang)
            data.forEach((codeArr, idx) => {
                const code = codeArr[0]
                var desc = codeArr[1]
                const descArr = desc.split("\n")
                var finalDesc = ""
                descArr.forEach((descLine, idx) => {
                    const whiteSpace = descLine.search(/\S/)
                    if (commentSymbol.length < 2 || idx === 0) {
                        finalDesc += insert(descLine, whiteSpace, commentSymbol[0])
                    }
                    if (commentSymbol.length > 1 && idx === descArr.length - 1) {
                        finalDesc = finalDesc + commentSymbol[1] + "\n"
                    }
                })

                finalCode += finalDesc + "\n\n" + code
                pairs.push(finalCode)
            })
            return "\n"+pairs.join("\n")
        }

        return "\n"+data
    }

    function insert(str, index, value) {
        return str.substr(0, index) + value + str.substr(index)
    }
</script></body></html>