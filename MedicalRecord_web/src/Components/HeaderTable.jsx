import { PiEyedropperSample } from 'react-icons/pi'
import { SiApmterminals } from 'react-icons/si'
import React from 'react'

export function HeaderTable({ data }) {
  const gridColsClass = `md:grid-cols-${data.length}`
  return (
    <div className={`hidden md:grid gap-4 mb-10 p-4 ${gridColsClass}`}>
      {data.map((header, index) => (
        <h5 key={index}>{header}</h5>
      ))}
    </div>
  )
}
