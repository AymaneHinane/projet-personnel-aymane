import React, { Component } from 'react'



class LifeCycle extends Component {

    constructor(props)
    {
        super(props)
        this.state= {
            step:1
        }
    }


  

    render() { 
        console.log('render parent ')
        return (
            <div>
               
                bonjour
                
            </div>
        )
    }
}

export default LifeCycle
