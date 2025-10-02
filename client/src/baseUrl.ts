//client/src/baseUrl.ts

import { MainClient } from "./generated-ts-client.ts";

const isProduction = import.meta.env.PROD;

const prod = "https://server-spring-water-3792.fly.dev";
const dev = "http://localhost:5253"; // Change to your local backend port if needed

export const finalUrl = isProduction ? prod : dev;

export const mainClient = new MainClient(finalUrl);
