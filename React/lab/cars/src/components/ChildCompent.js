import React, { Component } from 'react'

export class ChildCompent extends Component {

    constructor(props)
    {
        super(props)
      

    }

  

    render() {
        console.log('render enfant')
        return (
            <div>
               
                <p>elle s'est enerve</p>
            </div>
        )
    }
}

export default ChildCompent
