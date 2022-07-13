using Godot;
using System;

public class player : KinematicBody2D
{
    
    Vector2 velocity= new Vector2();
    float speed = 60;
    float gravity = 10;
    float jumpingPower= -300;
    float countjump=0;
    int MAX_JUMP = 1;
    AnimatedSprite anime;
    Vector2 floor= new Vector2(0,-1);
    public override void _Ready()
    {
        anime=(AnimatedSprite)GetNode("AnimatedSprite");
    }


 public override void _PhysicsProcess(float delta)
{
     if(Input.IsActionPressed("ui_right"))
     {
         anime.Play("run");
        velocity.x = speed;
        anime.FlipH = false;
     }
     else if(Input.IsActionPressed("ui_left"))
     {
    anime.Play("run");
         velocity.x = -speed;
         anime.FlipH = true;
     }
     else
     {
         velocity.x = 0;
         anime.Play("idle");
     }
     
     
     if(Input.IsActionJustPressed("ui_up")&& countjump<MAX_JUMP )
     {
        velocity.y=jumpingPower;
        countjump++;   
    }
            if(!IsOnFloor())
     {
         anime.Play("jump");
     }
   
    if(IsOnFloor())
     { 
         countjump=0;
    }
     velocity.y += gravity;
     velocity = MoveAndSlide(velocity,floor);
     
}
}
