import React, { Component } from 'react'
import Supsayen from './Supsayen'


export class Vegeta extends Component {


    render() {
        const {hits}=this.props
        console.log(this.props)
        return (
            <div>
                 <p>hello wold {hits} </p>
            </div>
        )
    }
}

export default Supsayen(Vegeta)
