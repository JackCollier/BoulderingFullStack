const PROXY_CONFIG = [
  {
    context: [
      "/api/Boulder",
    ],
    target: "https://localhost:7100",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
