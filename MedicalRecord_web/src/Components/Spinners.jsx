import React from 'react'
import { Spinner } from './Spinner'

export function Spinners({ number }) {
  const spinners = []
  const gridColsClass = `md:grid-cols-${number}`
  for (let i = 0; i < number; i++) {
    spinners.push(<Spinner key={i} />)
  }

  return (
    <div
      className={`grid grid-cols-1 ${gridColsClass} gap-4 items-center mb-4 bg-secondary-900 p-4 rounded-xl`}
    >
      {spinners}
    </div>
  )
}
