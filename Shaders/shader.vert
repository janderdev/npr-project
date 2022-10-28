#version 330 core

layout(location=0) in vec3 aPosition;
// layout(location = 1) in vec4 aColor;

out vec4 ourColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main(void)
{
    ourColor = vec4(0.4745, 0.3137, 0.2471, 1.0);
    gl_Position = vec4(aPosition, 1) * model * view * projection;
}