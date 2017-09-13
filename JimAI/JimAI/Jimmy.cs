using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIFramework;
using AIFramework.Entities;
using AIFramework.Actions;

namespace JimAI
{
    public class Jimmy:Agent
    {
        public AIVector startPos = null;

        public Jimmy(IPropertyStorage propertyStorage) : base(propertyStorage)
        {
        }

        public override void ActionResultCallback(bool success)
        {
            throw new NotImplementedException();
        }

        public override IAction GetNextAction(List<IEntity> otherEntities)
        {
            List<IEntity> nearEnemies = otherEntities.FindAll(x => x.GetType() != typeof(Jimmy) && x is Agent && AIVector.Distance(Position, x.Position) < AIModifiers.maxMeleeAttackRange);
            List<IEntity> farEnemies = otherEntities.FindAll(x => x.GetType() != typeof(Jimmy) && x is Agent && AIVector.Distance(Position, x.Position) > AIModifiers.maxMeleeAttackRange);
            List<IEntity> nearFood = otherEntities.FindAll(x => x.GetType() != typeof(Jimmy) && x is Plant && AIVector.Distance(Position, x.Position) < AIModifiers.maxFeedingRange);
            List<IEntity> farFood = otherEntities.FindAll(x => x.GetType() != typeof(Jimmy) && x is Plant && AIVector.Distance(Position, x.Position) > AIModifiers.maxFeedingRange);
            List<IEntity> nearFriends = otherEntities.FindAll(x => x.GetType() == typeof(Jimmy) && x != this && AIVector.Distance(Position, x.Position) < AIModifiers.maxProcreateRange);
            List<IEntity> farFriends = otherEntities.FindAll(x => x.GetType() == typeof(Jimmy) && x != this && AIVector.Distance(Position, x.Position) > AIModifiers.maxProcreateRange);

            if (startPos == null)
            {
                startPos = this.Position;
            }
            if (Hunger > AIModifiers.maxHungerBeforeHitpointsDamage / 2)
            {
                if (this.ProcreationCountDown <= 0)
                {
                    IEntity nearestPartner = null;

                    foreach (IEntity x in nearFriends)
                    {
                        if (nearestPartner == null || AIVector.Distance(Position, nearestPartner.Position) > AIVector.Distance(Position, x.Position))
                        {
                            nearestPartner = x;
                        }
                    }

                    if (AIVector.Distance(Position, nearestPartner.Position) < AIModifiers.maxProcreateRange)
                    {

                    }
                }
            }
        }
    }
}
