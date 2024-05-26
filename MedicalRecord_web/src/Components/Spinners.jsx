import React from 'react'
import { Spinner } from './Spinner'

export function Spinners({ number }) {
  const spinners = []
  for (let i = 0; i < number; i++) {
    spinners.push(<Spinner key={i} />)
  }

  return (
    <div
      className={`grid grid-cols-1 md:grid-cols-${number} gap-4 items-center mb-4 border-gray-500  p-4 rounded-xl`}
    >
      {spinners}
    </div>
  )
}
