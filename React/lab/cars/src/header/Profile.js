import React, { Component } from 'react'
import User from './User'
import {MyContext} from './MyContext'

class Profile extends Component {

    state={
        id:null,
        name:"aymane"
    }
    
    componentDidMount(){
        this.setState({
           id: this.props.match.params.profileId
        })
        
    }

    render() {
        return (
            <div>
                <MyContext.Provider value={this.state.name}>
                   <h1>profile1</h1>
                   <User /> 
                </MyContext.Provider>
                
            </div>
        )
    }
}



export default Profile
