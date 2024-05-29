```markdown
# ServerSwitcher Plugin

## Overview
ServerSwitcher facilitates server switching in Unturned, allowing users to seamlessly transition between different game servers. It provides commands to list available servers and switch to a specific server.

## Commands and Syntax

### `/servers`
- **Syntax**: `/servers` or `/svs`
- **Description**: Lists all available servers.
- **Permission**: `ServerSwitcher:commands.servers`

### `/server [name]`
- **Syntax**: `/server [name]` or `/sv [name]`
- **Description**: Switches to the server with the specified name.
- **Parameters**:
  - `name`: The name of the server to switch to.
- **Permission**: `ServerSwitcher:commands.server`

## Permissions

### `ServerSwitcher:commands.server`
- **Description**: Grants access to the `/server` command.

### `ServerSwitcher:commands.servers`
- **Description**: Grants access to the `/servers` command.

## Configuration

### Servers Configuration
You can define multiple servers in the configuration file. Each server requires a name, IP address, port, and optional password.
You can set the IP address of a server to be either a domain name or an IPv4 address. Both formats are supported in the configuration.

#### Server Configuration Example
```yaml
Servers:
  ServerList:
  - name: US1
    ip: play.lyhme.gg
    port: 27015
    password: ""
  - name: US2
    ip: "109.109.109.109"
    port: 27016
    password: ""
```
```
