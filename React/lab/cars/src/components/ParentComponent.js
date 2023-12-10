import React, { Component } from 'react'
import SimpleComponents from './SimpleComponents'
import Purecomponent from './Purecomponent'


export class ParentComponent extends Component {

    state={
        name:"aymane"
    }
 
    changeToBatman=()=>{
        this.setState({
            name:"Batman"
        })
    }


    render() {
        console.log('parent')
        return (
            <div>
                <SimpleComponents name={this.state.name} />
                <Purecomponent  name={this.state.name} />

                <button onClick={this.changeToBatman}>click here</button>
            </div>
        )
    }
}

export default ParentComponent
