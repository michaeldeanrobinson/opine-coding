import { Resvg } from "@resvg/resvg-js";
import toIco from "to-ico";
import { readFileSync, writeFileSync } from "fs";
import { resolve } from "path";

const root = resolve(process.cwd());
const svgPath = resolve(root, "src/OpineCoding.Api/wwwroot/favicon.svg");
const icoPath = resolve(root, "src/OpineCoding.Api/wwwroot/favicon.ico");
const socialPath = resolve(root, "src/OpineCoding.Api/wwwroot/social-preview.png");

const svg = readFileSync(svgPath, "utf8");

const icoSizes = [16, 32, 64];
const socialSize = 1280;

const render = (size) => new Resvg(svg, { fitTo: { mode: "width", value: size } }).render().asPng();

const icoBuffers = icoSizes.map(render);
const ico = await toIco(icoBuffers);
writeFileSync(icoPath, ico);
console.log(`favicon.ico written with sizes: ${icoSizes.join(", ")}px`);

// Wrap the icon in a 2:1 (64x32) canvas so social-preview renders at 1280x640.
// The original 32x32 icon is centred with 16px padding on each side.
const innerSvg = svg.replace(/<svg[^>]*>/, "").replace(/<\/svg>/, "");
const socialSvg = `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 64 32">
  <rect width="64" height="32" fill="#0f172a"/>
  <g transform="translate(16, 0)">${innerSvg}</g>
</svg>`;

const socialPng = new Resvg(socialSvg, { fitTo: { mode: "width", value: socialSize } }).render().asPng();
writeFileSync(socialPath, socialPng);
console.log(`social-preview.png written at ${socialSize}x${socialSize / 2}px`);
