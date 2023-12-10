import React, { Component } from 'react'

class AddHits extends Component {

   
state={
    fighter:{
       vegeta:true
    },
    hits:0
}

    render() {
        return (
            <div>
                {this.props.render(this.state.hits,this.state.fighter)}
            </div>
        )
    }
}

export default AddHits
