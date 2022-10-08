"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const fastify_1 = __importDefault(require("fastify"));
const server = (0, fastify_1.default)();
let lastVal = undefined;
server.post("/set", async (request, reply) => {
    lastVal = request.body;
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
