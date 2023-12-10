import React, { Component } from 'react'
import  '../myCss.css'





export class Style extends Component {
    render() {



        return (
            <div>
                 <h1 >Commentaire</h1>
                 <p className={`red bigFont`}>hello wold</p>
                 <button>valider</button>
            </div>
        )
    }
}

export default Style
