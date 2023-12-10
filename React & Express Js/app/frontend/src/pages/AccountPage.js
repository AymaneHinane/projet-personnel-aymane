import React, { useContext } from 'react'
import { UserContext } from '../UserContext';

export default function Account() {

  const {user} = useContext(UserContext);

  return (
    <div>Account {!!user&& user.name}</div>
  )
}
