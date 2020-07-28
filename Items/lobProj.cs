using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace bl3guns.Items
{
    public class lobProj : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.timeLeft = 200;
			projectile.frame = 4;
			projectile.frameCounter = 8;
			projectile.noDropItem = true;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.maxPenetrate = 150;
			projectile.tileCollide = false;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(250, 206, 116, 0) * (1f - (float)projectile.alpha / 255f);
		}
		public override void AI()
		{
			if (Main.rand.Next(0) == 0)
			{
				int choice = Main.rand.Next(6);
				if (choice == 0)
				{
					choice = 231;
				}
				else if (choice == 1)
				{
					choice = 6;
				}
				else if (choice == 2)
				{
					choice = 162;
				}
				else if (choice == 3)
				{
					choice = 231;
				}
				else if (choice == 4)
				{
					choice = 6;
				}
				else if (choice == 5)
				{
					choice = 162;
				}
				else
				{
					choice = 271;
				}
				Dust.NewDust(projectile.position, projectile.width, projectile.height, choice, projectile.velocity.X * 0.25f, projectile.velocity.Y * -0.25f, 150, default(Color), 0.8f);
				Dust.NewDust(projectile.position, projectile.width, projectile.height, choice, projectile.velocity.X * 0.25f, projectile.velocity.Y * -0.25f, 150, default(Color), 0.8f);
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 162, projectile.velocity.X * 0.25f, projectile.velocity.Y * -0.25f, 150, default(Color), 0.8f);
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 320f)
			{
				// Fade out
				projectile.alpha += 300;
				if (projectile.alpha > 255)
				{
					projectile.alpha = 255;
				}
			}
			else
			{
				// Fade in
				projectile.alpha -= 25;
				if (projectile.alpha < 30)
				{
					projectile.alpha = 0;
				}
			}
			// Slow down
			projectile.velocity *= 0.99f;
			// Loop through the 4 animation frames, spending 5 ticks on each.
			if (++projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
			projectile.rotation += 0.05f * (float)projectile.direction;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.OnFire, 240, true);
			}
		}
	}
}