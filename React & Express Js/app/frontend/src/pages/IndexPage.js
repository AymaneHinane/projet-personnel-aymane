import React ,{useContext} from 'react'
import { UserContext } from '../UserContext'

export default function IndexPage() {
    const {user} = useContext(UserContext)
    return (
        <div>
            {/* Index Page {user? user.email:"not connect"} */}
            not connected
        </div>

    )
}
