// src/server.ts
import express from "express"
import http from "http"
import socketIo from "socket.io"

const app = express()
const server = http.createServer(app)
const io = new socketIo.Server(server)

app.get("/", (req, res) => {
  res.sendFile(
    __dirname + "/index.html"
  )
})

io.on("connection", (socket) => {
  console.log("A user connected")

  socket.on("disconnect", () => {
    console.log("User disconnected")
  })

  socket.on("chat message", (msg) => {
    io.emit("chat message", msg)
  })

  socket.on("receiveMessage", (msg) => {
    console.log("Client sent: ", msg)
  })
})

const PORT = 3000
server.listen(PORT, () => {
  console.log(
    `Server listening on port ${PORT}`
  )
})
