import React, { Component } from 'react'
import ContentData from './ContentData'
import {userContext} from './MyContent'

class ProfileData extends Component {
    render() {
         let value=this.context;
        return (
            <div>
                <h1>ProfileData {value.name}</h1>
                <ContentData />
            </div>
        )
    }
}
ProfileData.contextType=userContext;

export default ProfileData
