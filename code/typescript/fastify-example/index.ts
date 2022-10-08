import fastify from "fastify";

const server = fastify();

let lastVal: string | undefined = undefined;

server.post("/set", async (request, reply) => {
  lastVal = request.body as string;
});

server.get("/get", async (request, reply) => {
  return lastVal;
});

server.listen({ port: 55555 }, (err, address) => {
  if (err) {
    console.error(err);
    process.exit(1);
  }
  console.log(`Server listening at ${address}`);
});
