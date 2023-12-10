import React, { Component } from 'react'
import Childui from './Childui'
import Childstate from './Childstate'


export class Parent extends Component {

    constructor(props)
    {
        super(props)
        
        this.refUI=React.createRef()

        this.state={
            value:''
        }
    }
    

    handleInput =(e)=>{
        
        this.setState({
            value:e.target.value
        })
        console.log(this.state.value)
    }
    
    handleClick= ()=>{
        console.log('handle btn')
    }

    componentDidUpdate(prevProps, prevState) {
         console.log("i'm here")
    }
    

    render() {
        console.log(this.refUI)
        return (
            <div>
                <Childui ref={this.refUI}/>
                <Childstate />
                <p>parent</p>
                <input type="text" value={this.state.value} onChange={this.handleInput}/>
                <button onClick={this.handleClick}>click here</button>
            </div>
        )
    }
}

export default Parent
