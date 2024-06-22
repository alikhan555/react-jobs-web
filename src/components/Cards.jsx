import React from 'react'

const Cards = ({children, bgColor}) => {
  return (
    <div className={`${bgColor} p-6 rounded-lg shadow-md`}>
      {children}
    </div>
  )
}

export default Cards
